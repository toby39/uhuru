using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace memoire.Models
{
    [Table("tarif")]
    public class Tarif
    {
        public int id { get; set; }
        public string designation { get; set; }
        public string tranfert { get; set; }
        public string uptime { get; set; }
        public string description { get; set; }
    }
}
