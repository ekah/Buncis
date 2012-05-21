using Buncis.Core.Infrastructures;
using Buncis.Framework.Mvp.Presenters;
using Buncis.Framework.Mvp.Views;
using WebFormsMvp;
using System;

namespace Buncis.Logic.Presenters
{
	public abstract class CorePresenter<TView> : BasePresenter<TView> where TView : class, ICustomEventView
	{
		protected ISystemSettings SystemSettings;

		protected CorePresenter(ISystemSettings systemSettings, TView view)
			: base(view)
		{
			SystemSettings = systemSettings;

			view.Initialize += view_Initialize;
		}

        protected CorePresenter(TView view)
			: base(view)
		{
			view.Initialize += view_Initialize;
		}

		protected virtual void view_Initialize(object sender, EventArgs e)
		{
			// this method can be overriden
		}
	}
}