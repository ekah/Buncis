using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Buncis.Web
{
	public partial class Home : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			Page.Title = "Buncis - Love, Strength, Motivation, Inspiration, Sharing";
			Page.MetaDescription = "Daily Bread for our strength, Motivational articles and stories for our spirit, Testimonies for our inspiration, and Other Information to enrich our knowledge.";
		}
	}
}