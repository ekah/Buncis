using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buncis.Data.Models;

namespace Buncis.Core.Services
{
    public interface IProductService
    {
        Product GetProductByProductId(int id);
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProducts(int? categoryId, int? supplierId);
    }
}
