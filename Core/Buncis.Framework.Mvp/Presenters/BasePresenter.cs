using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebFormsMvp;

namespace Buncis.Framework.Mvp.Presenters
{
    public class BasePresenter<TView> : Presenter<TView> where TView : class, IView
    {
        public BasePresenter(TView view)
            : base(view)
        {

        }
    }
}
