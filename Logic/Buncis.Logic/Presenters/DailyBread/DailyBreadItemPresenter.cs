using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buncis.Framework.Core.Resources;
using Buncis.Framework.Core.ViewModel;
using Buncis.Logic.Views.DailyBread;
using Buncis.Framework.Core.Services.DailyBread;
using Buncis.Web.Common.Utility;
using Buncis.Web.Common.Exceptions;
using Omu.ValueInjecter;
using Buncis.Framework.Core.SupportClasses.Injector;

namespace Buncis.Logic.Presenters.DailyBread
{
	public class DailyBreadItemPresenter : LogicPresenter<IDailyBreadDetailView>
	{
		private readonly IDailyBreadService _dailyBreadService;

		public DailyBreadItemPresenter(IDailyBreadDetailView view,
			IDailyBreadService dailyBreadService)
			: base(view)
		{
			_dailyBreadService = dailyBreadService;

			view.GetDailyBreadDetail += view_GetDailyBreadDetail;
		}

		void view_GetDailyBreadDetail(object sender, EventArgs e)
		{
			var dailyBreadId = int.Parse(WebUtil.GetQueryString(QueryStrings.DailyBreadDetailId, "-1"));
			var dailyBreadItem = _dailyBreadService.GetDailyBreadItem(dailyBreadId);
			if (dailyBreadItem == null)
			{
				throw new PageNotFoundException("The Page is not found in database", WebUtil.GetCurrentUrl());
			}

			View.Model.DailyBreadId = dailyBreadItem.DailyBreadId;
			View.Model.DailyBreadTitle = dailyBreadItem.DailyBreadTitle;
			View.Model.DailyBreadSummary = dailyBreadItem.DailyBreadSummary;
			View.Model.DailyBreadUrl = dailyBreadItem.DailyBreadUrl;
			View.Model.DailyBreadContent = dailyBreadItem.DailyBreadContent;
			View.Model.DailyBreadBible = string.Format("{0} {1}:{2}-{3}",
				dailyBreadItem.DailyBreadBook,
				dailyBreadItem.DailyBreadBookChapter,
				dailyBreadItem.DailyBreadBookVerse1,
				dailyBreadItem.DailyBreadBookVerse2);
			View.Model.DailyBreadBibleContent = dailyBreadItem.DailyBreadBookContent;
			View.Model.DatePublished = dailyBreadItem.DatePublished;

			View.BindDailyBreadDetail();
		}
	}
}
