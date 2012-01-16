using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buncis.Data.Models;

namespace Buncis.Core.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategories();
    }
}
