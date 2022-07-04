using Microsoft.EntityFrameworkCore;
using MohamedRefaat.Domain.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MohamedRefaat.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }


        public DbSet<Product> Products { get; set; }

        public DbSet<MohamedRefaat.Domain.Models.Customer.Customer> Customers { get; set; }

        public DbSet<MohamedRefaat.Domain.Models.Order.Order> Orders { get; set; }

        public DbSet<MohamedRefaat.Domain.Models.Order.ProductOrder> ProductOrders { get; set; }


    }
}
