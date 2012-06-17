using System;
using WebFormsMvp;

namespace Buncis.Framework.Mvp.Presenters
{
    public class BasePresenter<TView> : Presenter<TView> where TView : class, IView
    {
        public BasePresenter(TView view)
            : base(view)
        {
            view.Load += view_Load;            
        }

        protected virtual void view_Load(object sender, EventArgs e)
        {
            // this can be overriden
        }
    }
}