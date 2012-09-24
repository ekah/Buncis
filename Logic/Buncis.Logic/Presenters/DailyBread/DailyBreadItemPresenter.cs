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
		}

		protected override void view_Initialize(object sender, EventArgs e)
		{
			var dailyBreadId = int.Parse(WebUtil.GetQueryString(QueryStrings.DailyBreadDetailId, "-1"));
			var dailyBreadItem = _dailyBreadService.GetDailyBreadItem(dailyBreadId);
			if (dailyBreadItem == null)
			{
				throw new PageNotFoundException("The Page is not found in database", WebUtil.GetCurrentUrl());
			}

			View.Model.DailyBreadItem = new ViewModelDailyBreadItem();
			View.Model.DailyBreadItem.InjectFrom<CloneInjection>(dailyBreadItem);
			View.BindViewData();
		}
	}
}
