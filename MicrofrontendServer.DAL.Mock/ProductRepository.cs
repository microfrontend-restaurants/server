using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroforntendServer.Domain;

namespace MicrofrontendServer.DAL.Mock
{
    public class ProductRepository : IProductRepository
    {

        private static IEnumerable<Product> products;

        public ProductRepository()
        {
            products = new List<Product>
            {
                new Product { Id = 0, Name = "Basic TV", Price = 999.99, Brand = new Brand { Id = 0 }, Category = new Category { Id = 0 } }
            };
        }

        public IEnumerable<Product> GetProducts()
        {
            return products;
        }
    }
}
