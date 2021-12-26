using Application.Interfaces;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace Infrastracture
{
    public class ProduitDbContext:DbContext
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTime _dateTime;

        public ProduitDbContext(ICurrentUserService currentUserService,IDateTime dateTime)
        {
            _currentUserService = currentUserService;
            _dateTime = dateTime;
        }
        public ProduitDbContext()
        {

        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _currentUserService.UserId;
                        entry.Entity.Created = _dateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = _currentUserService.UserId;
                        entry.Entity.LastModified = _dateTime.Now;
                        break;
                    case EntityState.Deleted:
                        entry.Entity.DeletedBy = _currentUserService.UserId;
                        entry.Entity.DeletedAt = _dateTime.Now;
                        break;


                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        public DbSet<Produit> Produits { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=TestDatabase;Trusted_Connection=True;"
                , options => options.EnableRetryOnFailure()
                );
        }
    }
}
