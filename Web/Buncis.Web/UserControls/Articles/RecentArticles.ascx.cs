using System;
using Buncis.Logic.Models.Articles;
using Buncis.Logic.Presenters.Articles;
using Buncis.Web.Base;
using WebFormsMvp;
using Buncis.Logic.Views.Articles;

namespace Buncis.Web.UserControls.Articles
{
	[PresenterBinding(typeof(RecentArticlesPresenter), ViewType = typeof(IRecentArticlesView))]
	public partial class RecentArticles : BaseLogicUserControl<RecentArticlesModel>, IRecentArticlesView
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			GetRecentArticles(this, new EventArgs());
		}

		#region Implementation of IBindableView<RecentArticlesModel>

		public void BindViewData()
		{

		}

		#endregion

		#region Implementation of IRecentArticlesView

		public event EventHandler GetRecentArticles;
		public void BindRecentArticles()
		{
			rptRecentArticles.DataSource = Model.RecentArticles;
			rptRecentArticles.DataBind();
		}

		#endregion
	}
}