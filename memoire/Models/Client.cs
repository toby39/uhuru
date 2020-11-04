using System.ComponentModel.DataAnnotations.Schema;

namespace memoire.Models
{
 
        [Table("client")]
        public class Client
        {
            public int id { get; set; }
            public string noms { get; set; }
            public string sexe { get; set; }
            public string telephone { get; set; }
            public double solde { get; set; }
        }
}
