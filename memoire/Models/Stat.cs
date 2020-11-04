using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace memoire.Models
{
    [Table("stat")]
    public class Stat
    {
        public int id { get; set; }
    }
}
