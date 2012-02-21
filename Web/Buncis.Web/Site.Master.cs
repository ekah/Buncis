using System;
using System.Web.UI.HtmlControls;

namespace Buncis.Web
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        public HtmlGenericControl Menu
        {
            get
            {
                return this.menu;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
    }
}