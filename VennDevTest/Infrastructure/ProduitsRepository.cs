using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VennDevTest.Entities;

namespace VennDevTest.Infrastructure
{
    public class ProduitsRepository : IProduitRepository
    {
        private readonly ProduitDbContext _dbContext;

        public ProduitsRepository(ProduitDbContext dbContext)
        {
            _dbContext = dbContext;
        }  
        public IEnumerable<Produit> GetAllProduits()
        {
            var produits = _dbContext.Produits.ToList();
            return produits;
        }

        public Produit GetProduitById(Guid id)
        {
            var produit = _dbContext.Produits.Where(u=>u.Id == id).FirstOrDefault();
            return produit;
        }

        public Produit AddProduit(Produit produit)
        {
            var newproduit = _dbContext.Produits.Add(produit);
            return newproduit.Entity;
        }
        public void SaveChange()
        {
            _dbContext.SaveChanges();

        }

        public void DeleteProduct(Produit produit)
        {
            _dbContext.Remove(produit);
        }

        public Produit EditeProduct(Produit produit)
        {
            var response=_dbContext.Produits.Update(produit);
            return response.Entity;
        }
    }
}
