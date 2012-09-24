using Buncis.Framework.Mvp.Presenters;
using Buncis.Framework.Mvp.Views;
using System;
using Buncis.Framework.Core.Infrastructure.Settings;
using Buncis.Web.Common.Membership;

namespace Buncis.Logic.Presenters
{
	public abstract class LogicPresenter<TView> : BasePresenter<TView> where TView : class, ICustomEventView
	{
		//protected ISystemSettings SystemSettings;

		protected int ClientId
		{
			get
			{
				return WebMembershipProvider.Instance.LoggedInWebUserProfile.ClientId;
			}
		}

		//protected LogicPresenter(ISystemSettings systemSettings, TView view)
		//    : base(view)
		//{
		//    SystemSettings = systemSettings;

		//    view.Initialize += view_Initialize;
		//}

		protected LogicPresenter(TView view)
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