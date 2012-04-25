using System;
using System.Web.UI;
using System.Web;

namespace Buncis.Web
{
    public partial class NotFound : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpContext.Current.Response.StatusCode = 302;
        }
    }
}