using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VennDevTest.Entities
{
    public class Produit
    {
        public Guid Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public double Prix { get; set; }
        public bool EnStock { get; set; }
        public int Quantite { get; set; }
    }
}
