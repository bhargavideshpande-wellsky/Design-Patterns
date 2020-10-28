using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caching
{
    class Program
    {
        static void Main(string[] args)
        {
            IProductService productService = new ProductCacheService();
            List<Product> products = productService.GetProducts();
            Console.WriteLine("Enter Product Id:");
            int id = int.Parse(Console.ReadLine());
            Product product = productService.GetProductById(id);
            Console.WriteLine("Your Product ID is: " + product.Id);
            Console.WriteLine("Enter Product Id:");
            id = int.Parse(Console.ReadLine());
            product = productService.GetProductById(id);
            Console.WriteLine("Your Product ID is: " + product.Id);
            Console.ReadKey();
        }
    }
}