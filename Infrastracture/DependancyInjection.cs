using Application.Interfaces;
using Application.IRepositories;
using Infrastracture;
using Infrastracture.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddInfrastructureDependancy(this IServiceCollection service,IConfiguration configuration)
        {
            service.AddDbContext<ProduitDbContext>
                (
                );
            service.AddTransient<IProduitRepository, ProduitsRepository>();
            service.AddTransient<IDateTime, DateTimeService>();

            return service;
        }

    }
}
