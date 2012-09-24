using System;
using Buncis.Data.Domain.News;
using Buncis.Framework.Core.Infrastructure.Utility;
using Buncis.Framework.Core.Resources;

namespace Buncis.Services.Url
{
	public class NewsUrlEngine : IUrlEngine<NewsItem>
	{
		public int ModuleId
		{
			get
			{
				return 20;
			}
		}

		public string GenerateUrl(int id, string title, DateTime date)
		{
			// /[YEAR]/[MONTH]/[DAY]/20/[calculatedid+catid]/[news title] << NEWS 
			// format the url
			var friendlyUrl = string.Format("/{0}/{1}/{2}/{3}/{4}/{5}",
				date.Year,
				date.Month,
				date.Day,
				ModuleId,
				id > 0 ? UrlUtility.Scramble(id).ToString() : "[TBD]",
				UrlUtility.CleanTitle(title));

			// return 
			return friendlyUrl;
		}

		public string ResolveUrl(string friendlyUrl)
		{
			// /[YEAR]/[MONTH]/[DAY]/20/[calculatedid+catid]/[news title] << NEWS 

			var splitted = friendlyUrl.Split('/');
			int year, month, day, moduleId, rawId;

			if (splitted.Length == 6
				&& int.TryParse(splitted[0], out year)
				&& int.TryParse(splitted[0], out month)
				&& int.TryParse(splitted[0], out day)
				&& int.TryParse(splitted[3], out moduleId)
				&& int.TryParse(splitted[4], out rawId))
			{
				try
				{
					var date = new DateTime(year, month, day);
					var cleanId = UrlUtility.Translate(rawId);
					return string.Format("{0}?{1}={2}",
						Redirections.Page_NewsDetail,
						QueryStrings.NewsDetail_NewsId,
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
