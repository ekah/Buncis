using System.Collections.Generic;
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