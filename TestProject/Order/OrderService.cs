

using MohamedRefaat.Domain.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTest
{
    public class  OrderService : IOrderService
    {
        private readonly List<ProductOrder> _order;

        public OrderService()
        {
            _order = new List<ProductOrder>()
            {
                new ProductOrder() { Id = 1,
                      OrderId=1, ProductId =1 },
               new ProductOrder() { Id = 2,
                      OrderId=2, ProductId =2 }
            };
        }

        public IEnumerable<ProductOrder> GetAllItems()
        {
            return _order;
        }


    }
}
