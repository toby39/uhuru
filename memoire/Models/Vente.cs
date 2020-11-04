using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace memoire.Models
{
    [Table("vente")]
    public class Vente
    {
        public int id { get; set; }
        public string numero { get; set; }
        public DateTime date { get; set; }
        public string paquet { get; set; }
        public string password { get; set; }
        public int Revendeurid { get; set; }
        public Revendeur Revendeur { get; set; }
        public int Clientid { get; set; }
        public Client Client { get; set; }
    }
}
