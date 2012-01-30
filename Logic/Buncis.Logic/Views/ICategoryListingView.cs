using System;
using Buncis.Framework.Mvp.Views;
using Buncis.Logic.Models;

namespace Buncis.Logic.Views
{
    public interface ICategoryListingView : IBaseView<CategoryListingModel>
    {
        event EventHandler GetCategories;
    }
}