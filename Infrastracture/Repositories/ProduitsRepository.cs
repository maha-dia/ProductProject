using Application.IRepositories;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace Infrastracture.Repositories
{
    public class ProduitsRepository : IProduitRepository
    {
        private readonly ProduitDbContext _dbContext;

        public ProduitsRepository(ProduitDbContext dbContext)
        {
            _dbContext = dbContext;
        }  
        public async Task<List<Produit>> GetAllProduitsAsync(CancellationToken cancellationToken)
        {
            var produits = await _dbContext.Produits.ToListAsync();
            return produits;
        }

        public async Task<Produit> GetProduitByIdAsync(Guid id,CancellationToken cancellationToken)
        {
            var produit =await _dbContext.Produits.Where(u=>u.Id == id).FirstOrDefaultAsync();
            return produit;
        }

        public async Task<Produit> AddProduitAsync(Produit produit, CancellationToken cancellationToken)
        {
            var newproduit = await _dbContext.Produits.AddAsync(produit);
            return newproduit.Entity;
        }
        public async Task SaveChangeAsync()
        {
            await _dbContext.SaveChangesAsync();

        }

        public void DeleteProduct(Produit produit)
        {
            _dbContext.Remove(produit);
        }

        
    }
}
