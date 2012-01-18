using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buncis.Data.Models;

namespace Buncis.Logic.Models
{
    public class ProductListingModel
    {
        public IEnumerable<Product> Products { get; set; }
    }
}
