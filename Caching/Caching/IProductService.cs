using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caching
{
    interface IProductService
    {
        List<Product> GetProducts();
        Product GetProductById(int id);
    }
}

