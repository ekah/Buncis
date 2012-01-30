using System.Collections.Generic;
using Buncis.Data.Models;

namespace Buncis.Logic.Models
{
    public class ProductListingModel
    {
        public IEnumerable<Product> Products { get; set; }

        public IEnumerable<Supplier> Suppliers { get; set; }

        public IEnumerable<Category> Categories { get; set; }
    }
}