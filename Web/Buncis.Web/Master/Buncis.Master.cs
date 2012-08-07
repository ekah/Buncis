using System;
using System.Web.UI;
using Buncis.Web.Common.Utility;
using System.IO;
using Buncis.Framework.Core.Membership;
using Buncis.Web.Common.Membership;

namespace Buncis.Web.Master
{
	public partial class Buncis : MasterPage
	{
        protected IUserProfile CurrentProfile
        {
            get
            {
                return WebMembershipProvider.Instance.LoggedInWebUserProfile;
            }
        }

		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected override void Render(HtmlTextWriter writer)
		{
			using (var htmlwriter = new HtmlTextWriter(new StringWriter()))
			{
				base.Render(htmlwriter);

				HtmlCleaner.Render(htmlwriter, writer);
			}
		}
	}
}