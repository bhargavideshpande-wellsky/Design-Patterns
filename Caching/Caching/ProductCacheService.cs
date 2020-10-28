using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caching
{
    class ProductCacheService : ICacheService
    {
        private IProductService _productService;
        private CacheMemoryProvider _memoryCachProvider;
        public ProductCacheService()
        {
            _productService = new ProductService();
            _memoryCachProvider = new CacheMemoryProvider();
        }
        public Product GetProductById(int id)
        {
            Product product = (Product)_memoryCachProvider.GetItem(Convert.ToString(id));
            if (product != null)
            {
                Console.WriteLine("Data From Cache");
                return product;
            }
            product = _productService.GetProductById(id);
            _memoryCachProvider.AddItem(Convert.ToString(product.Id), product);
            return product;
        }

        public List<Product> GetProducts()
        {
            List<Product> products = _productService.GetProducts();
            return products;
        }
    }
}
