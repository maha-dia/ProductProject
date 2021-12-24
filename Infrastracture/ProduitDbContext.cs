using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Infrastracture
{
    public class ProduitDbContext:DbContext
    {
        public DbSet<Produit> Produits { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=TestDatabase;Trusted_Connection=True;"
                ,options => options.EnableRetryOnFailure()
                );
        }
    }
}
