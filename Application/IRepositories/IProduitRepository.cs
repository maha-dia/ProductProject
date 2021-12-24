using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Application.IRepositories
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
