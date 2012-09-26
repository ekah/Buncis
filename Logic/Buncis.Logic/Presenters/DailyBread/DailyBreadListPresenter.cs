using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buncis.Logic.Views.DailyBread;
using Buncis.Framework.Core.Services.DailyBread;
using Buncis.Logic.CustomEventArgs;

namespace Buncis.Logic.Presenters.DailyBread
{
	public class DailyBreadListPresenter : LogicPresenter<IDailyBreadListView>
	{
		private readonly IDailyBreadService _dailyBreadService;

		public DailyBreadListPresenter(IDailyBreadListView view, IDailyBreadService dailyBreadService)
			: base(view)
		{
			_dailyBreadService = dailyBreadService;

			view.GetDailyBreadList += view_GetDailyBreadList;
		}

		void view_GetDailyBreadList(object sender, EventArgs e)
		{
			var ae = e as DailyBreadListEventArgs;
			var data = _dailyBreadService.GetAvailableDailyBreadItems(ae.ClientId);
			data = data.OrderByDescending(o => o.DatePublished).ToList();

			View.Model.DailyBreadItems = data;
			View.BindDailyBreadList(); 
		}
	}
}
