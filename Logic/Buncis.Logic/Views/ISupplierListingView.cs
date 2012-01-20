using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buncis.Framework.Mvp.Views;
using Buncis.Logic.Models;

namespace Buncis.Logic.Views
{
    public interface ISupplierListingView : IBaseView<SupplierListingModel>
    {
        event EventHandler GetSuppliers;
    }
}
