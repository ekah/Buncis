using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Buncis.Web.Base;
using Buncis.Web.Common.Membership;

namespace Buncis.Web.UserControls.Component
{
	public partial class LoginInfo : BaseUserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				loginInfoUsername.InnerText = WebMembershipProvider.Instance.LoggedInWebUserProfile.FullName;
			}
		}
	}
}