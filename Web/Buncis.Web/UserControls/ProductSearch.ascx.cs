using System;
using System.Web.UI.WebControls;
using Buncis.Framework.Mvp.Controls;
using Buncis.Logic.CustomEventArgs;
using Buncis.Logic.Models;
using Buncis.Logic.Presenters;
using Buncis.Logic.Views;
using Buncis.Web.Common.Extensions;
using WebFormsMvp;

namespace Buncis.Web.UserControls
{
    [PresenterBinding(typeof(ProductListingPresenter), ViewType = typeof(IProductListingView))]
    public partial class ProductSearch : BuncisMvpUserControl<ProductListingModel>, IProductListingView
    {
        public event SearchProductsEventHandler SearchProducts;
        public event EventHandler Initialize;

        protected override void OnInit(EventArgs e)
        {
            btnSearch.Click += new EventHandler(btnSearch_Click);

            ddlCategories.DataValueField = "CategoryId";
            ddlCategories.DataTextField = "CategoryName";

            ddlSuppliers.DataValueField = "SupplierId";
            ddlSuppliers.DataTextField = "CompanyName";

            base.OnInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Initialize != null)
                {
                    Initialize(this, e);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var categoryId = string.IsNullOrEmpty(ddlCategories.SelectedValue) ? (int?)null : int.Parse(ddlCategories.SelectedValue);
            var supplierId = string.IsNullOrEmpty(ddlSuppliers.SelectedValue) ? (int?)null : int.Parse(ddlSuppliers.SelectedValue);

            if (SearchProducts != null)
            {
                SearchProducts(this, new ProductListingEventArgs()
                {
                    CategoryId = categoryId,
                    SupplierId = supplierId
                });

                rptProducts.DataSource = Model.Products;
                rptProducts.DataBind();
            }
        }

        public void BindSupplierDropDownList()
        {
            ddlSuppliers.Items.Clear();
            ddlSuppliers.InsertListItem_All();

            foreach (var item in Model.Suppliers)
            {
                ddlSuppliers.Items.Add(new ListItem(item.CompanyName, item.SupplierId.ToString()));
            }

            ddlSuppliers.DataBind();
        }

        public void BindCategoryDropDownList()
        {
            ddlCategories.Items.Clear();
            ddlCategories.InsertListItem_All();

            foreach (var item in Model.Categories)
            {
                ddlCategories.Items.Add(new ListItem(item.CategoryName, item.CategoryId.ToString()));
            }

            ddlCategories.DataBind();
        }
    }
}