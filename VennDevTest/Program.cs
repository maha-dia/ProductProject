using Application.Interfaces;
using Core.Entities;
using Infrastracture;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Services;

namespace VennDevTest
{
    public class Program
    {
        public static void Main(string[] args)
        {

            using (var db = new ProduitDbContext( ))
            {

                if (db.Produits.Count() == 0)
                {
                    db.Database.EnsureDeleted();
                    db.Database.EnsureCreated();
                    db.Produits.Add(new Produit { Id = new Guid(), Nom = "pro-1", Description = "", EnStock = true, Image = null, Prix = 12236, Quantite = 155 });
                    db.Produits.Add(new Produit { Id = new Guid(), Nom = "pro-2", Description = "", EnStock = false, Image = null, Prix = 12536, Quantite = 175 });
                    db.Produits.Add(new Produit { Id = new Guid(), Nom = "pro-3", Description = "", EnStock = true, Image = null, Prix = 122, Quantite = 115 });
                    db.SaveChanges();
                }


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
