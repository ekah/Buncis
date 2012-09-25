using System;
using System.Web.UI;
using System.IO;
using Buncis.Web.Common.Utility;

namespace Buncis.Web.Master
{
	public partial class Custom : MasterPage
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