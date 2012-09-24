using System;
using Buncis.Framework.Core.Infrastructure.Extensions;
using Buncis.Logic.Presenters.News;
using Buncis.Web.Common.Exceptions;
using WebFormsMvp;
using Buncis.Logic.Views.DailyBread;
using Buncis.Logic.Presenters.DailyBread;
using Buncis.Logic.Models.DailyBread;
using Buncis.Web.Base;

namespace Buncis.Web.DailyBread
{
	[PresenterBinding(typeof(DailyBreadItemPresenter), ViewType = typeof(IDailyBreadDetailView))]
	public partial class Detail : BaseLogicPage<DailyBreadModel>, IDailyBreadDetailView
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

		#region Implementation of IBindableView<DailyBreadModel>

		public void BindViewData()
		{
			ltrTitle.Text = string.Format("<a href=\"{0}\">{1}</a>", Model.DailyBreadItem.DailyBreadUrl, Model.DailyBreadItem.DailyBreadTitle);
			ltrInfo.Text = Model.DailyBreadItem.DatePublished.ToBuncisShortFormatString();
			ltrContent.Text = Model.DailyBreadItem.DailyBreadContent;
			ltrBible.Text = string.Format("{0} {1} : {2} - {3}",
				Model.DailyBreadItem.DailyBreadBook,
				Model.DailyBreadItem.DailyBreadBookChapter,
				Model.DailyBreadItem.DailyBreadBookVerse1,
				Model.DailyBreadItem.DailyBreadBookVerse2);
			ltrBibleContent.Text = Model.DailyBreadItem.DailyBreadBookContent;
		}

		#endregion
	}
}