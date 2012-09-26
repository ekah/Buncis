using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Buncis.Framework.Core.Infrastructure.Extensions;
using Buncis.Logic.Views.News;
using Buncis.Logic.Models.News;
using Buncis.Web.Base;
using Buncis.Logic.Presenters.News;
using Buncis.Web.Common.Exceptions;
using WebFormsMvp;
using Buncis.Web.Common.Utility;

namespace Buncis.Web.News
{
	[PresenterBinding(typeof(NewsItemPresenter), ViewType = typeof(INewsDetailView))]
	public partial class Detail : BaseLogicPage<NewsModel>, INewsDetailView
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				GetNewsDetail(this, new EventArgs());
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

		#region Implementation of IBindableView<NewsModel>

		public void BindViewData()
		{
		}

		#endregion

		#region Implementation of INewsDetailView

		public event EventHandler GetNewsDetail;
		public void BindNewsDetail()
		{
			ltrNewsTitle.Text = string.Format("<a href=\"{0}\">{1}</a>", Model.NewsUrl, Model.NewsTitle);
			ltrNewsInfo.Text = Model.DatePublished.ToBuncisShortFormatString();
			ltrContent.Text = Model.NewsContent;

			Page.Title = Model.NewsTitle;
			Page.MetaDescription = Model.NewsSummary;
		}

		#endregion
	}
}