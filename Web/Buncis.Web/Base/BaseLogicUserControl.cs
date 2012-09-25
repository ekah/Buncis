using System;
using System.Linq;
using Buncis.Web.Common.Membership;
using WebFormsMvp.Web;
using Buncis.Framework.Mvp.Views;
using Buncis.Framework.Mvp.CustomEventArgs;
using Buncis.Framework.Core.Membership;
using System.Web;

namespace Buncis.Web.Base
{
	public class BaseLogicUserControl<TModel> : MvpUserControl<TModel>, ICustomEventView where TModel : class, new()
	{
		public event EventHandler Initialize;

		protected void InitializeView(object sender, EventArgs e)
		{
			Initialize(sender, e);
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