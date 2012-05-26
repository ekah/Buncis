using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buncis.Framework.Mvp.Views;
using Buncis.Logic.Models.Pages;

namespace Buncis.Logic.Views.Pages
{
    public interface IBuncisPageListingView : IBindableView<BuncisPageListingModel>
    {
        event EventHandler GetList;
    }
}
