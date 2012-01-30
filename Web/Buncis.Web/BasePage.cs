using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace Buncis.Web
{
    public class BasePage : System.Web.UI.Page
    {
        protected string MenuTitle { get; set; }


        protected override void OnPreRender(EventArgs e)
        {
            var master = Page.Master;
            if (master != null && master is SiteMaster)
            {
                var siteMaster = (SiteMaster)Page.Master;
                var links = siteMaster.Menu.Controls;
                foreach (Control ctrl in links)
                {
                    if (ctrl is HtmlAnchor)
                    {
                        var link = (HtmlAnchor)ctrl;
                        var title = link.Attributes["title"];
                        if (title.Equals(MenuTitle, StringComparison.OrdinalIgnoreCase))
                        {
                            link.Attributes.Add("class", "menu-selected");
                        }
                    }
                }
            }

            base.OnPreRender(e);
        }
    }
}
