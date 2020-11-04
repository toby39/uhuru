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
    [Route("agence")]
    public class AgenceController : Controller
    {

        private readonly DataContext db;

        public AgenceController(DataContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            ViewBag.Agences = db.Agences.ToList();
            return View();
        }

        [Route("add")]
        public IActionResult Add()
        {
            //ViewBag.Clients = db.Agences.ToList();
            return View();
        }
    }
}
