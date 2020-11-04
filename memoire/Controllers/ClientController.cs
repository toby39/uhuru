using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using memoire.Models;

namespace memoire.Controllers
{
    [Route("client")]
    public class ClientController : Controller
    {
        private readonly DataContext db;

        public ClientController(DataContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            ViewBag.Clients = db.Clients.ToList();
            return View();
        }

        [Route("add")]
        public IActionResult Add()
        {
            ViewBag.Clients = db.Clients.ToList();
            return View();
        }


        [HttpPost]
        [Route("add")]
        public IActionResult Add(Client client)
        {
            db.Clients.Add(client);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            db.Clients.Remove(db.Clients.Find(id));
            db.SaveChanges();

            return RedirectToAction("Index");
        }


        [HttpGet]
        [Route("edit/{id}")]
        public IActionResult Edit(int id)
        {
            return View("Edit", db.Clients.Find(id));
        }

        [HttpPost]
        [Route("edit/{id}")]
        public IActionResult Edit(int id,Client client)
        {
            db.Entry(client).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
