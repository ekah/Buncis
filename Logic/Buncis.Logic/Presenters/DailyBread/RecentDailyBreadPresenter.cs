using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buncis.Framework.Core.Services.DailyBread;
using Buncis.Logic.Views.DailyBread;

namespace Buncis.Logic.Presenters.DailyBread
{
	public class RecentDailyBreadPresenter : LogicPresenter<IRecentDailyBreadView>
	{
		private readonly IDailyBreadService _dailyBreadService;

		public RecentDailyBreadPresenter(IRecentDailyBreadView view, IDailyBreadService dailyBreadService)
			: base(view)
		{
			_dailyBreadService = dailyBreadService;

			view.GetRecentDailyBread += view_GetRecentDailyBread;
		}

		void view_GetRecentDailyBread(object sender, EventArgs e)
		{
			var recentDailyBread = _dailyBreadService.GetRecentDailyBread(ClientId);
			View.Model.RecentDailyBread = recentDailyBread;

			View.BindRecentDailyBread();
		}
	}
}
