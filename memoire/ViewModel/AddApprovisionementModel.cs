using memoire.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace memoire.ViewModel
{
    public class AddApprovisionementModel
    {
        public int id { get; set; }
        public string numero { get; set; }
        public DateTime date { get; set; }
        public int quantite { get; set; }
        public string unite { get; set; }
        public int Revendeurid { get; set; }
        public Revendeur Revendeur { get; set; }
        public IList<Revendeur> Revendeurs { get; set; }
    }
}
