using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buncis.Web.Common.DynamicControls
{
	public static class ControlsContainer
	{
		private static readonly Dictionary<string, DynamicControl> dynamicControls = new Dictionary<string, DynamicControl>();

		public static void InitializeDynamicControls()
		{
			// todo: probably can change the key to guid
			dynamicControls.Add(DynamicControlsLibrary.NEWS_LIST, new DynamicControl { ControlKey = "NewsList", RenderTag = "<bun:NewsList runat=\"server\" ID=\"ucNewsList1\" />" });
		}
	}
}
