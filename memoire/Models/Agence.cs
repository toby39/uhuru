using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace memoire.Models
{
    [Table("agence")]
    public class Agence
    {
        public int id { get; set; }
        public string designation { get; set; }
        public string adresse { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}
