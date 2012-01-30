using System;

namespace Buncis.Web
{
    public partial class About : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.MenuTitle = "about";
        }
    }
}