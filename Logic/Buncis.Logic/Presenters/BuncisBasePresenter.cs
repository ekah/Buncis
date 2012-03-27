using Buncis.Core.Infrastructures;
using Buncis.Framework.Mvp.Presenters;
using Buncis.Framework.Mvp.Views;
using WebFormsMvp;
using System;

namespace Buncis.Logic.Presenters
{
    public abstract class BuncisBasePresenter<TView> : BasePresenter<TView> where TView : class, IView
    {
        protected ISystemSettings SystemSettings;

        protected BuncisBasePresenter(ISystemSettings systemSettings, TView view)
            : base(view)
        {
            SystemSettings = systemSettings;
        }

        protected BuncisBasePresenter(TView view)
            : base(view)
        {
            
        }
    }
}