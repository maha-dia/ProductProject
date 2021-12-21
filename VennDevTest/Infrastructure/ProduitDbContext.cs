﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VennDevTest.Entities;

namespace VennDevTest.Infrastructure
{
    public class ProduitDbContext:DbContext
    {
        public DbSet<Produit> Produits { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-LJ0NQCQ;Database=TestDatabase;Trusted_Connection=True;");
        }
    }
}