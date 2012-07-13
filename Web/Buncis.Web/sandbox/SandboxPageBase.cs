using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Buncis.Framework.Core.Membership;
using Buncis.Web.Common.Membership;

namespace Buncis.Web.sandbox
{
	public class SandboxPageBase : Page
	{
		protected IUserProfile CurrentProfile
		{
			get
			{
				return WebMembershipProvider.Instance.LoggedInWebUserProfile;
			}
		}
	}
}