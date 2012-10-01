using System;
using Buncis.Framework.Core.Infrastructure.Extensions;
using Buncis.Logic.Presenters.Articles;
using Buncis.Logic.Views.Articles;
using Buncis.Logic.Models.Articles;
using Buncis.Web.Common.Exceptions;
using WebFormsMvp;
using Buncis.Web.Base;
using Buncis.Web.Common.Utility;

namespace Buncis.Web.Modules.Articles
{
	[PresenterBinding(typeof(ArticleItemPresenter), ViewType = typeof(IArticleDetailView))]
	public partial class Detail : BaseLogicPage<ArticleModel>, IArticleDetailView
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				GetArticleDetail(this, new EventArgs());
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

		}

		#endregion

		#region Implementation of IArticleDetailView

		public event EventHandler GetArticleDetail;
		public void BindArticleDetail()
		{
			ltrArticleTitle.Text = string.Format(@"<a href=""{0}"">{1}</a>", Model.ArticleUrl, Model.ArticleTitle);
			ltrArticleInfo.Text = Model.DateCreated.ToBuncisShortFormatString();
			ltrContent.Text = Model.ArticleContent;

			Page.Title = Model.ArticleTitle;
			Page.MetaDescription = Model.ArticleSummary;

			ltrSocial.Text = WebUtil.GetSocialBar(Model.ArticleUrl);

			WebUtil.PutFBOpenGraphMetaTag(this.Page, Model.ArticleTitle, Model.ArticleSummary, Model.ArticleUrl);
		}

		#endregion
	}
}