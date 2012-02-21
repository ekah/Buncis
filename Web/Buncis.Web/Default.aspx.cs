using Buncis.Web.Common.Membership;
namespace Buncis.Web
{
    public partial class _Default : BasePage
    {
        protected override void OnInit(System.EventArgs e)
        {
            this.MenuTitle = "home";

            base.OnInit(e);
        }

        protected override void OnLoad(System.EventArgs e)
        {
            WebMembership.Entity.DoLogin("", "");

            base.OnLoad(e);
        }
    }
}