using System;
using Buncis.Framework.Mvp.Views;
using Buncis.Logic.Models;

namespace Buncis.Logic.Views
{
    public interface ISupplierListingView : IBaseView<SupplierListingModel>
    {
        event EventHandler GetSuppliers;
    }
}