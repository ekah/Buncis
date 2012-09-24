using System;
using Buncis.Framework.Core.Infrastructure.Extensions;
using Buncis.Logic.Presenters.Articles;
using Buncis.Logic.Views.Articles;
using Buncis.Logic.Models.Articles;
using Buncis.Web.Common.Exceptions;
using WebFormsMvp;
using Buncis.Web.Base;

namespace Buncis.Web.Articles
{
	[PresenterBinding(typeof(ArticleItemPresenter), ViewType = typeof(IArticleDetailView))]
	public partial class Detail : BaseLogicPage<ArticleModel>, IArticleDetailView
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				InitializeView();
			}
			catch (PageNotFoundException pnfex)
			{
				Response.StatusCode = 404;
			}
			catch (Exception ex)
			{
				// for now remove all error to 404
				Response.StatusCode = 404;
			}
		}

		#region Implementation of IBindableView<ArticleModel>

		public void BindViewData()
		{
			ltrArticleTitle.Text = string.Format("<a href=\"{0}\">{1}</a>", Model.ArticleItem.ArticleUrl, Model.ArticleItem.ArticleTitle);
			ltrArticleInfo.Text = Model.ArticleItem.DateCreated.ToBuncisShortFormatString();
			ltrContent.Text = Model.ArticleItem.ArticleContent;
		}

		#endregion
	}
}