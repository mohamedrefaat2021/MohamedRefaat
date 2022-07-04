
using MohamedRefaat.Domain.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTest
{
    public class  ProductService : IProductService
    {
        private readonly List<Product> _product;

        public ProductService()
        {
            _product = new List<Product>()
            {
                new Product() { Id = 1,
                     ProductName = "Orange ",  Quantity="100",  Description ="Test", SupplierName="Ahmed" , Notes="No Notes" },
               new Product() { Id = 2,
                     ProductName = "Apple ",  Quantity="100",  Description ="Test", SupplierName="Ahmed" , Notes="No Notes" },
            };
        }

        public IEnumerable<Product> GetAllItems()
        {
            return _product;
        }

        public Product Add(Product newItem)
        {
            newItem.Id = 2;
            _product.Add(newItem);
            return newItem;
        }

      

        public void Remove(int id)
        {
            var existing = _product.First(a => a.Id == id);
            _product.Remove(existing);
        }

    }
}
