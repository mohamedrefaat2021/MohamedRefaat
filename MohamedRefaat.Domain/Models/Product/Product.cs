using MohamedRefaat.Domain.Models.Order;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MohamedRefaat.Domain.Models.Product
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string ProductName { get; set; }

        public string SupplierName { get; set; }

        public string Quantity { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }


        


    }
}
