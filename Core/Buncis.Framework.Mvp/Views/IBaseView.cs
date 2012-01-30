using System;
using WebFormsMvp;

namespace Buncis.Framework.Mvp.Views
{
    public interface IBaseView<T> : IView<T> where T : class, new()
    {
        event EventHandler Initialize;
    }
}