using System;
using Buncis.Logic.Models.News;
using Buncis.Logic.Presenters.News;
using Buncis.Logic.Views.News;
using Buncis.Web.Base;
using WebFormsMvp;

namespace Buncis.Web.UserControls.News
{
	[PresenterBinding(typeof(RecentNewsPresenter), ViewType = typeof(IRecentNewsView))]
	public partial class RecentNews : BaseLogicUserControl<RecentNewsModel>, IRecentNewsView
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			GetRecentNews(this, new EventArgs());
		}

		#region Implementation of IBindableView<RecentNewsModel>

		public void BindViewData()
		{

		}

		#endregion

		#region Implementation of IRecentNewsView

		public event EventHandler GetRecentNews;
		public void BindRecentNews()
		{
			rptRecentNews.DataSource = Model.RecentNews;
			rptRecentNews.DataBind();
		}

		#endregion
	}
}