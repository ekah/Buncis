using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buncis.Framework.Mvp.Presenters;
using WebFormsMvp;
using Buncis.Core.Infrastructures;

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
    }
}
