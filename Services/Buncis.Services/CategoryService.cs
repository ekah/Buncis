using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buncis.Core.Services;
using Buncis.Data.Models;
using Buncis.Core.Repositories;

namespace Buncis.Services
{
    public class CategoryService : Base.BuncisBaseService, ICategoryService
    {
        private ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _categoryRepository.GetAll().ToList();
        }
    }
}
