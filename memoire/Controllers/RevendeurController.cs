 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using memoire.Models;

namespace memoire.Controllers
{
    [Route("revendeur")]
    public class RevendeurController : Controller
    {
        private readonly DataContext db;

        public RevendeurController(DataContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            ViewBag.Revendeurs = db.Revendeurs.ToList();
            return View();
        }

        [Route("add")]
        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        [Route("add")]
        public IActionResult Add(Revendeur revendeur)
        {
            db.Revendeurs.Add(revendeur);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            db.Revendeurs.Remove(db.Revendeurs.Find(id));
            db.SaveChanges();

            return RedirectToAction("Index");
        }


        [HttpGet]
        [Route("edit/{id}")]
        public IActionResult Edit(int id)
        {
            return View("Edit", db.Revendeurs.Find(id));
        }

        [HttpPost]
        [Route("edit/{id}")]
        public IActionResult Edit(int id, Revendeur revendeur)
        {
            db.Entry(revendeur).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
