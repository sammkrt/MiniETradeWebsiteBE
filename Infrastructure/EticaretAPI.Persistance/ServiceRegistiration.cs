using EticaretAPI.Application.Abstractions;
using EticaretAPI.Persistance.Concretes;
using EticaretAPI.Persistance.Contexts;
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
        }
    }
}
