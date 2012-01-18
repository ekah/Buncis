using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buncis.Data.Models;
using Buncis.Framework.Mvp.Views;

namespace Buncis.Logic.Views
{
    public interface ISupplierListingView : IBaseView<Supplier>
    {
        event EventHandler GetSuppliers;
    }
}
