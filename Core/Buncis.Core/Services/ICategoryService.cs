using System.Collections.Generic;
using Buncis.Data.Models;

namespace Buncis.Core.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategories();
    }
}