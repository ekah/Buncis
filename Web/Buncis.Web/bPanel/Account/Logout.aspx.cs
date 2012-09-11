using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Buncis.Web.Common.Membership;
using Buncis.Framework.Core.Resources;

namespace Buncis.Web.bPanel.Account
{
	public partial class Logout : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			var currentLoggedInUserId = WebMembershipProvider.Instance.LoggedInWebUserProfile.UserId;
			var response = WebMembershipProvider.Instance.DoLogout(currentLoggedInUserId);
			Response.Redirect(response.IsSuccess ? Redirections.Page_Buncis_Login : Request.UrlReferrer.AbsoluteUri);
		}
	}
}