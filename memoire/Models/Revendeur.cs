using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace memoire.Models
{
    [Table("revendeur")]
    public class Revendeur
    {
        public int id { get; set; }
        public string noms { get; set; }
        public string sexe { get; set; }
        public string telephone { get; set; }
        public double solde { get; set; }
        public IList<Approvisionement> Approvisionement { get; set; }
    }
}
