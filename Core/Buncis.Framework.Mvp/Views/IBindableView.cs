using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebFormsMvp;

namespace Buncis.Framework.Mvp.Views
{
    public interface IBindableView<TModel> : IBaseView<TModel> where TModel : class, new()
    {
        void BindViewData();
    }
}
