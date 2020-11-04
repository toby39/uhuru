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
    [Route("user")]
    public class UserController : Controller
    {
        private DataContext db = new DataContext();

        public IActionResult Index()
        {
            ViewBag.Users = db.Users.ToList();
            return View();
        }

        [Route("add")]
        public IActionResult Add()
        {
            return View();
        }
    }
}
