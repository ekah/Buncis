using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebFormsMvp;

namespace Buncis.Framework.Mvp.Views
{
    public interface IBaseView<T> : IView<T> where T : class, new()
    {
        event EventHandler Initialize;
    }
}
