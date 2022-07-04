using MohamedRefaat.Domain.Models.Order;
using MohamedRefaat.Domain.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllItems();
        Product Add(Product newItem);

        void Remove(int id);
    }
}
