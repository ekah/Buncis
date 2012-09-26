using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Buncis.Web.Common.Utility;

namespace Buncis.Web.Master
{
	public partial class Custom8s : MasterPage
	{
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