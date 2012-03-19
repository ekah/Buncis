using System;
using System.Web;
using System.Web.UI;

namespace Buncis.Web.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" +
                                            HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
        }
    }
}