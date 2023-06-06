using EticaretAPI.Application.Abstractions;
using EticaretAPI.Application.Repositories.CustomerRepositories;
using EticaretAPI.Application.Repositories.OrderRepositories;
using EticaretAPI.Application.Repositories.ProductRepositories;
using EticaretAPI.Persistance.Concretes;
using EticaretAPI.Persistance.Contexts;
using EticaretAPI.Persistance.Repositories.CustomerRepos;
using EticaretAPI.Persistance.Repositories.OrderRepos;
using EticaretAPI.Persistance.Repositories.ProductRepos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EticaretAPI.Persistance
{
    public static class ServiceRegistiration
    {

        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("MsSql");
            services.AddDbContext<ETicaretAPIDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
        }
    }
}
