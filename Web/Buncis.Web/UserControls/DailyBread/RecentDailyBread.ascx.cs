using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Buncis.Logic.Presenters.DailyBread;
using WebFormsMvp;
using Buncis.Logic.Views.DailyBread;
using Buncis.Logic.Models.DailyBread;
using Buncis.Web.Base;

namespace Buncis.Web.UserControls.DailyBread
{
	[PresenterBinding(typeof(RecentDailyBreadPresenter), ViewType = typeof(IRecentDailyBreadView))]
	public partial class RecentDailyBread : BaseLogicUserControl<RecentDailyBreadModel>, IRecentDailyBreadView
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			GetRecentDailyBread(this, new EventArgs());
		}

		public event EventHandler GetRecentDailyBread;

		public void BindRecentDailyBread()
		{
			rptRecentDailyBread.DataSource = Model.RecentDailyBread;
			rptRecentDailyBread.DataBind();
		}

		public void BindViewData()
		{

		}
	}
}