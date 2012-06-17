using System;
using System.Web.UI;
using Buncis.Web.Common.Utility;
using System.IO;
using Buncis.Web.Common.Membership;

namespace Buncis.Web.bPanel.Account
{
    public partial class Login : Page
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            SetupEventHandlers();
        }

        private void SetupEventHandlers()
        {
            btnLogin.ServerClick += new EventHandler(btnLogin_ServerClick);
        }

        void btnLogin_ServerClick(object sender, EventArgs e)
        {
           var loginResponse = WebMembershipProvider.Instance.DoLogin(txtUsername.Value, txtPassword.Value);
           if (!loginResponse.IsSuccess)
           {
               
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