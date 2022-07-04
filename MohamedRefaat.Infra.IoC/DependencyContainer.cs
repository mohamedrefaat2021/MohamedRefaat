using Microsoft.Extensions.DependencyInjection;
using MohamedRefaat.Application.Interfaces;
using MohamedRefaat.Application.Services;
using MohamedRefaat.Domain.IRepository;
using MohamedRefaat.Infra.Data.Context;
using MohamedRefaat.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MohamedRefaat.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
          
            services.AddScoped<ApplicationDbContext>();
           
            services.AddTransient(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));            

            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<IOrderService, OrderService>();

        }
    }
}
