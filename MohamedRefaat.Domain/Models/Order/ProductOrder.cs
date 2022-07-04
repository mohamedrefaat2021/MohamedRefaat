using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MohamedRefaat.Domain.Models.Order
{
    public class ProductOrder
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int ProductId { get; set; }
        public MohamedRefaat.Domain.Models.Product.Product Product { get; set; }


        public int Quantity { get; set; }

        public decimal Price { get; set; }


    }
}
