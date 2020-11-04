using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using memoire.Models;
using memoire.ViewModel;
using Microsoft.EntityFrameworkCore;
using tik4net;
using MessageBird;

namespace memoire.Controllers
{
    [Route("vente")]
    public class VenteController : Controller
    {
        private DataContext db = new DataContext();
        private static Random random = new Random();

        public IActionResult Index()
        {
            ViewBag.Ventes = db.Ventes.Include(a => a.Revendeur).Include(b => b.Client).ToList();
            return View();
        }

        [Route("prepareadd")]
        public IActionResult Prepareadd()
        {
            ViewBag.Clients = db.Clients.ToList();
            return View();
        }


        [Route("prepare/{id}")]
        public IActionResult Prepare(int id)
        {
            return RedirectToAction("Add", new { id = id });
        }

        [Route("add")]
        public IActionResult Add(int id)
        {
            ViewBag.Tarifs = db.Tarifs.ToList();
            ViewBag.Client = id;
            return View();
        }


        [HttpPost]
        [Route("add")]
        public IActionResult Add(Vente vente)
        {
            Guid g = Guid.NewGuid();
            vente.numero = "TXN" + g;
            vente.Revendeurid = 1;

            Models.Client client = new Models.Client();

            client = db.Clients.Where(x => x.id == vente.Clientid).SingleOrDefault();

            string pass = RandomString(6);

            using (ITikConnection connection = ConnectionFactory.CreateConnection(TikConnectionType.Api))
            {

                connection.Open("192.168.5.1", "admin", "");

                ITikCommand cmd = connection.CreateCommandAndParameters("/tool/user-manager/user/add", "customer", "admin", "username", client.telephone, "password",pass);

                ITikCommand cmd1 = connection.CreateCommandAndParameters("/tool/user-manager/user/create-and-activate-profile", "profile", vente.paquet, "customer", "admin", "numbers", client.telephone);

                var a = cmd.ExecuteScalar();

            }

            const string YourAccessKey = "zwZHzmIXkqgHaQkYwN0KQred4";
            MessageBird.Client cl = MessageBird.Client.CreateDefault(YourAccessKey);
            long Msisdn = Int64.Parse(client.telephone);
            MessageBird.Objects.Message message =
            cl.SendMessage("Uhuru Soft", "votre code d'acces WI-FI est "+pass+",en cas de soucis contactez : +243 997 854 029", new[] { Msisdn });



            vente.password = pass;
            db.Ventes.Add(vente);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            db.Approvisionements.Remove(db.Approvisionements.Find(id));
            db.SaveChanges();

            return RedirectToAction("Index");
        }


        [HttpGet]
        [Route("edit/{id}")]
        public IActionResult Edit(int id)
        {
            return View("Edit", db.Approvisionements.Find(id));
        }

        [HttpPost]
        [Route("edit/{id}")]
        public IActionResult Edit(int id, Approvisionement approvisionement)
        {
            db.Entry(approvisionement).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
