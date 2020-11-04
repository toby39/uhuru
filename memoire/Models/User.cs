﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace memoire.Models
{
    [Table("user")]
    public class User
    {
        public int id { get; set; }
        public string noms { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}
