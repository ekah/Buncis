using System;
using System.Linq;
using Buncis.Logic.CustomEventArgs;
using Buncis.Web.Base;
using Buncis.Logic.Presenters.News;
using Buncis.Logic.Views.News;
using WebFormsMvp;
using Buncis.Logic.Models.News;

namespace Buncis.Web.UserControls.News
{
	[PresenterBinding(typeof(NewsListPresenter), ViewType = typeof(INewsListView))]
	public partial class NewsList : BaseLogicUserControl<NewsListModel>, INewsListView
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			GetNewsList(this, new NewsListEventArgs { ClientId = CurrentProfile.ClientId });
		}

		#region Implementation of IBindableView<NewsListModel>

		public void BindViewData()
		{

		}

		#endregion

		#region Implementation of INewsListView

		public event EventHandler GetNewsList;
		public void BindNewsList()
		{
			rptNewsList.DataSource = Model.NewsItems;
			rptNewsList.DataBind();
		}

		#endregion
	}
}