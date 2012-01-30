using System.Collections.Generic;
using Buncis.Data.Models;

namespace Buncis.Logic.Models
{
    public class CategoryListingModel
    {
        public IEnumerable<Category> Categories { get; set; }
    }
}