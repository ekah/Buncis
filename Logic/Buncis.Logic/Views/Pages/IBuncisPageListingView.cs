using System;
using System.Linq;
using Buncis.Framework.Mvp.Views;
using Buncis.Logic.Models.Pages;

namespace Buncis.Logic.Views.Pages
{
    public interface IBuncisPageListingView : IBindableView<BuncisPageListingModel>
    {
        event EventHandler GetList;
    }
}
