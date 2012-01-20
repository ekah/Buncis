using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buncis.Framework.Mvp.Views;
using Buncis.Logic.Models;
using Buncis.Logic.CustomEventArgs;

namespace Buncis.Logic.Views
{
    public interface IProductListingView : IBaseView<ProductListingModel>
    {
        event SearchProductsEventHandler SearchProducts;

        void BindSupplierDropDownList();
        void BindCategoryDropDownList();
    }
}
