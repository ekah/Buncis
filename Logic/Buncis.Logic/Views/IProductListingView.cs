using Buncis.Framework.Mvp.Views;
using Buncis.Logic.CustomEventArgs;
using Buncis.Logic.Models;

namespace Buncis.Logic.Views
{
    public interface IProductListingView : IBaseView<ProductListingModel>
    {
        event SearchProductsEventHandler SearchProducts;

        void BindSupplierDropDownList();

        void BindCategoryDropDownList();
    }
}