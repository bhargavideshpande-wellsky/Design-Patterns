using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caching
{
    class ProductService : IProductService
    {
        public Product GetProductById(int id)
        {
            IRepository productRepo = new SqlRepository();
            Console.WriteLine("Data From Database:");
            return productRepo.GetProductById(id);
        }

        public List<Product> GetProducts()
        {
            IRepository productRepo = new SqlRepository();
            return productRepo.GetAllProducts();
        }
    }
}
