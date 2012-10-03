using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Buncis.Framework.Mvp.CustomEventArgs;
using Buncis.Logic.CustomEventArgs;
using Buncis.Logic.Presenters.DailyBread;
using Buncis.Logic.Views.DailyBread;
using Buncis.Web.Base;
using WebFormsMvp;
using Buncis.Logic.Models.DailyBread;

namespace Buncis.Web.UserControls.DailyBread
{
	[PresenterBinding(typeof(DailyBreadListPresenter), ViewType = typeof(IDailyBreadListView))]
	public partial class DailyBreadList : BaseLogicUserControl<DailyBreadListModel>, IDailyBreadListView
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			GetDailyBreadList(this, new DailyBreadListEventArgs { ClientId = CurrentProfile.ClientId });
		}

		#region Implementation of IBindableView<DailyBreadListModel>

		public void BindViewData()
		{

		}

		#endregion

		#region Implementation of IDailyBreadListView

		public event EventHandler GetDailyBreadList;
		public void BindDailyBreadList()
		{
			rptDailyBreadlist.DataSource = Model.DailyBreadItems;
			rptDailyBreadlist.DataBind();
		}

		#endregion
	}
}