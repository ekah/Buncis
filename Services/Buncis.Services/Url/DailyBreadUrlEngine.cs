using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buncis.Data.Domain.DailyBread;
using Buncis.Framework.Core.Infrastructure;
using Buncis.Framework.Core.Infrastructure.Utility;
using Buncis.Framework.Core.Resources;

namespace Buncis.Services.Url
{
	public class DailyBreadUrlEngine : IUrlEngine<DailyBreadItem>
	{
		public int ModuleId
		{
			get
			{
				return 50;
			}
		}

		public string GenerateUrl(int id, string title, DateTime date)
		{
			var friendlyUrl = string.Format("/{0}/{1}/{2}/{3}/{4}/{5}",
				date.Year,
				date.Month,
				date.Day,
				ModuleId,
				id > 0 ? UrlUtility.Scramble(id).ToString() : "[TBD]",
				UrlUtility.CleanTitle(title));

			return friendlyUrl;
		}

		public string ResolveUrl(string friendlyUrl)
		{
			if (friendlyUrl.StartsWith("/"))
			{
				friendlyUrl = friendlyUrl.TrimStart('/');
			}
			var splitted = friendlyUrl.Split('/');
			int year, month, day, moduleId, rawId;

			if (splitted.Length == 6
				&& int.TryParse(splitted[0], out year)
				&& int.TryParse(splitted[1], out month)
				&& int.TryParse(splitted[2], out day)
				&& int.TryParse(splitted[3], out moduleId)
				&& int.TryParse(splitted[4], out rawId))
			{
				try
				{
					var date = new DateTime(year, month, day);
					var cleanId = UrlUtility.Translate(rawId);
					return string.Format("{0}?{1}={2}",
						Redirections.Page_DailyBreadDetail,
						QueryStrings.DailyBreadDetailId,
						cleanId);
				}
				catch
				{
					return string.Empty;
				}
			}
			return string.Empty;
		}
	}
}
