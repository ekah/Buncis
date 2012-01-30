using System.Collections.Generic;
using System.Linq;
using Buncis.Core.Repositories;
using Buncis.Core.Services;
using Buncis.Data.Models;

namespace Buncis.Services
{
    public class CategoryService : Base.BuncisBaseService, ICategoryService
    {
        private ICategoryRepository _categoryRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryService"/> class.
        /// </summary>
        /// <param name="categoryRepository">The category repository.</param>
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        /// <summary>
        /// Gets all categories.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Category> GetAllCategories()
        {
            return _categoryRepository.GetAll().OrderBy(c => c.CategoryName).ToList();
        }
    }
}