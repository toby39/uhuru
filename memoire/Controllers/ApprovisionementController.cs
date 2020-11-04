using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using memoire.Models;
using memoire.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace memoire.Controllers
{
    [Route("approsionement")]
    public class ApprovisionementController : Controller
    {
        private DataContext db = new DataContext();
       
        
        public IActionResult Index()
        {
            ViewBag.Approvisionements = db.Approvisionements.Include(a => a.Revendeur ).ToList();
            return View();
        }

        [HttpGet("prepareadd")]
        public IActionResult Prepareadd()
        {
            ViewBag.Revendeurs = db.Revendeurs.ToList();
            return View();
        }


        [HttpGet("prepare/{id}")]
        public IActionResult Prepare(int id)
        {
            return RedirectToAction("Add",new { id = id });
        }

        [Route("add")]
        public IActionResult Add(int id)
        {
            ViewBag.Revendeur = id;
            return View();
        }


        [HttpPost]
        [Route("add")]
        public IActionResult Add(Approvisionement approvisionement)
        {
            Guid g = Guid.NewGuid();
            approvisionement.numero = "TXN"+g;
            db.Approvisionements.Add(approvisionement);
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
    }
}
