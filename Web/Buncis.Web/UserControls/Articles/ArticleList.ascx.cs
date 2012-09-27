using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Buncis.Logic.CustomEventArgs;
using Buncis.Logic.Presenters.Articles;
using Buncis.Logic.Views.Articles;
using WebFormsMvp;
using Buncis.Logic.Models.Articles;
using Buncis.Web.Base;

namespace Buncis.Web.UserControls.Articles
{
	[PresenterBinding(typeof(ArticleListPresenter), ViewType = typeof(IArticleListView))]
	public partial class ArticleList : BaseLogicUserControl<ArticleListModel>, IArticleListView
	{
		public int CategoryId { get; set; }

		protected void Page_Load(object sender, EventArgs e)
		{
			GetArticleList(this, new ArticleListEventArgs
									{
										ClientId = CurrentProfile.ClientId,
										CategoryId = CategoryId
									});
		}

		#region Implementation of IBindableView<ArticleListModel>

		public void BindViewData()
		{

		}

		#endregion

		#region Implementation of IArticleListView

		public event EventHandler GetArticleList;
		public void BindArticleList()
		{
			rptArticleList.DataSource = Model.ArticleItems;
			rptArticleList.DataBind();
		}

		#endregion
	}
}