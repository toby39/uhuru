﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace memoire.Controllers
{
    [Route("admin")]

    public class AdminController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
