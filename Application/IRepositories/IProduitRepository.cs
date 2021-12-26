using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace Application.IRepositories
{
    public interface IProduitRepository
    {
        Task<List<Produit>> GetAllProduitsAsync(CancellationToken cancellationToken);
        Task<Produit> GetProduitByIdAsync(Guid id,CancellationToken cancellationToken);
        Task<Produit> AddProduitAsync(Produit produit,CancellationToken cancellationToken);
        void SaveChangeAsync();
        void DeleteProduct(Produit produit);
    }
}
