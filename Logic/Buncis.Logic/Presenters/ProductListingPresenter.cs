using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buncis.Logic.Views;
using Buncis.Core.Infrastructures;
using Buncis.Core.Services;
using Buncis.Logic.CustomEventArgs;

namespace Buncis.Logic.Presenters
{
    public class ProductListingPresenter : BuncisBasePresenter<IProductListingView>
    {
        private IProductService _productService;
        private ISupplierService _supplierService;
        private ICategoryService _categoryService;

        public ProductListingPresenter(ISystemSettings systemSettings, IProductListingView view,
            IProductService productService,
            ICategoryService categoryService,
            ISupplierService supplierService)
            : base(systemSettings, view)
        {
            _productService = productService;
            _supplierService = supplierService;
            _categoryService = categoryService;

            view.Initialize += new EventHandler(view_Initialize);
            view.Load += new EventHandler(view_Load);
            view.SearchProducts += new CustomEventArgs.SearchProductsEventHandler(view_SearchProducts);
        }

        void view_Initialize(object sender, EventArgs e)
        {
            View.Model.Categories = _categoryService.GetAllCategories();
            View.Model.Suppliers = _supplierService.GetAllSuppliers();

            View.BindCategoryDropDownList();
            View.BindSupplierDropDownList();
        }

        protected void view_Load(object sender, EventArgs e)
        {

        }

        protected void view_SearchProducts(object sender, ProductListingEventArgs e)
        {
            View.Model.Products = _productService.GetProducts(e.CategoryId, e.SupplierId);
        }
    }
}
