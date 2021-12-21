using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VennDevTest.Entities;
using VennDevTest.Infrastructure;

namespace VennDevTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            using(var db= new ProduitDbContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
               
                db.Produits.Add(new Produit { Id = new Guid("20c5d60b-5b4c-4c48-bf0c-bc9c7e5af3eb"), Nom = "pro-1", Description = "", EnStock = true, Image = null, Prix = 12236, Quantite = 155 });
                db.Produits.Add(new Produit { Id = new Guid("61264d33-b442-4278-a052-17ff8c1b6b61"), Nom = "pro-2", Description = "", EnStock = false, Image = null, Prix = 12536, Quantite = 175 });
                db.Produits.Add(new Produit { Id = new Guid("9c48903c-0e45-4d27-908b-2f6abf4ed909"), Nom = "pro-3", Description = "", EnStock = true, Image = null, Prix = 122, Quantite = 115 });
                db.SaveChanges();
            }
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
