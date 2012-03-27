using System;
using WebFormsMvp;

namespace Buncis.Framework.Mvp.Views
{
    public interface IBaseView<TModel> : IView<TModel> where TModel : class, new()
    {
        event EventHandler Initialize;
    }
}