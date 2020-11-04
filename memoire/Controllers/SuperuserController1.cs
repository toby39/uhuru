using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using memoire.Models;

namespace memoire.Controllers
{
    [Route("superuser")]
    public class SuperuserController : Controller
    {
        private DataContext db = new DataContext();

       
        public IActionResult Index()
        {
            ViewBag.Superusers = db.Superusers.ToList();
            return View();
        }

        [Route("add")]
        public IActionResult Add()
        {
            return View();
        }
    }
}
