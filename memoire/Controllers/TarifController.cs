using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using memoire.Models;
using Microsoft.AspNetCore.Mvc;
using tik4net;

namespace memoire.Controllers
{
    [Route("tarif")]
    public class TarifController : Controller
    {
        private DataContext db = new DataContext();

        public IActionResult Index()
        {
            ViewBag.Tarifs = db.Tarifs.ToList();
            return View();
        }


        [Route("add")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add(Tarif tarif)
        {

            using (ITikConnection connection = ConnectionFactory.CreateConnection(TikConnectionType.Api))
            {
                // ici la connection passe très bien

                connection.Open("192.168.5.1", "admin", "");

                ITikCommand cmd1 = connection.CreateCommandAndParameters("/tool/user-manager/profile/add","name", tarif.designation, "owner", "admin", "validity", "0s");
                ITikCommand cmd2 = connection.CreateCommandAndParameters("/tool/user-manager/profile/limitation/add", "name", tarif.designation, "owner", "admin", "uptime-limit", tarif.uptime, "transfer-limit",tarif.tranfert);
                ITikCommand cmd3 = connection.CreateCommandAndParameters("/tool/user-manager/profile/profile-limitation/add", "from-time","0s", "limitation", tarif.designation, "profile", tarif.designation);

                  cmd1.ExecuteScalar();
                  cmd2.ExecuteNonQuery();
                  cmd3.ExecuteNonQuery();

                connection.Close();

            }
            
            db.Tarifs.Add(tarif);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            Tarif tarif = new Tarif();
            tarif = db.Tarifs.Find(id);

            using (ITikConnection connection = ConnectionFactory.CreateConnection(TikConnectionType.Api))
            {
                // ici la connection passe très bien

                connection.Open("192.168.5.1", "admin", "");

                ITikCommand cmd1 = connection.CreateCommandAndParameters("/tool/user-manager/profile/remove", tarif.designation);
                ITikCommand cmd2 = connection.CreateCommandAndParameters("/tool/user-manager/profile/limitation/remove", tarif.designation);

                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();

                connection.Close();

            }

           // db.tarifs.Remove(tarif);
           // db.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}
