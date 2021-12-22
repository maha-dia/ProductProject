using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VennDevTest.Entities;

namespace VennDevTest.Infrastructure
{
    public interface IProduitRepository
    {
        IEnumerable<Produit> GetAllProduits();
        Produit GetProduitById(Guid id);
        Produit AddProduit(Produit produit);
        void SaveChange();
        void DeleteProduct(Produit produit);
    }
}
