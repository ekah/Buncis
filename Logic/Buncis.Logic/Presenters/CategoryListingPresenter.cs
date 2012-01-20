using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buncis.Logic.Views;
using Buncis.Framework.Mvp.Presenters;
using Buncis.Core.Infrastructures;
using Buncis.Core.Services;

namespace Buncis.Logic.Presenters
{
    public class CategoryListingPresenter : BuncisBasePresenter<ICategoryListingView>
    {
        private ICategoryService _categoryService;

        public CategoryListingPresenter(ISystemSettings systemSettings, ICategoryListingView view, ICategoryService categoryService)
            : base(systemSettings, view)
        {
            _categoryService = categoryService;

            view.Load += new EventHandler(view_Load);
            view.GetCategories += new EventHandler(view_GetCategories);
        }

        void view_GetCategories(object sender, EventArgs e)
        {
            View.Model.Categories = _categoryService.GetAllCategories();
        }

        void view_Load(object sender, EventArgs e)
        {

        }
    }
}
