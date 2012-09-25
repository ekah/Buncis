using WebFormsMvp.Web;
using System;
using Buncis.Framework.Mvp.Views;
using System.Web;
using Buncis.Framework.Core.Membership;
using Buncis.Framework.Mvp.CustomEventArgs;
using Buncis.Web.Common.Membership;

namespace Buncis.Web.Base
{
	public class BaseLogicPage<TModel> : MvpPage<TModel>, ICustomEventView where TModel : class, new()
	{
		public event EventHandler Initialize;

		protected void InitializeView()
		{
			Initialize(this, new EventArgs());
		}

		protected IUserProfile CurrentProfile
		{
			get
			{
				return WebMembershipProvider.Instance.LoggedInWebUserProfile;
			}
		}
	}
}