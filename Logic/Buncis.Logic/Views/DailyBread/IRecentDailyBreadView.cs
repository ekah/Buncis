using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buncis.Framework.Mvp.Views;
using Buncis.Logic.Models.DailyBread;

namespace Buncis.Logic.Views.DailyBread
{
	public interface IRecentDailyBreadView : IBindableView<RecentDailyBreadModel>
	{
		event EventHandler GetRecentDailyBread;
		void BindRecentDailyBread();
	}
}
