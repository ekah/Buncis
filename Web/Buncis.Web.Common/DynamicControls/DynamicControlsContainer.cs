using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buncis.Web.Common.DynamicControls
{
    public static class DynamicControlsContainer
    {
        public static readonly Dictionary<string, DynamicControl> DynamicControls = new Dictionary<string, DynamicControl>();

        public static void InitializeDynamicControls()
        {
            // todo: probably can change the key to guid
            DynamicControls.Add(DynamicControlsLibrary.NEWS_LIST, new DynamicControl
            {
                ControlKey = "NewsList",
                RenderTag = "<bun:NewsList runat=\"server\" ID=\"ucNewsList1\" />",
                ControlPath = "~/UserControls/News/NewsList.ascx"
            });
        }
    }
}
