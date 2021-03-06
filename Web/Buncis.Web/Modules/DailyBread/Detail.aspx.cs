﻿using System;
using Buncis.Framework.Core.Infrastructure.Extensions;
using Buncis.Web.Common.Exceptions;
using Buncis.Web.Common.Utility;
using WebFormsMvp;
using Buncis.Logic.Views.DailyBread;
using Buncis.Logic.Presenters.DailyBread;
using Buncis.Logic.Models.DailyBread;
using Buncis.Web.Base;

namespace Buncis.Web.Modules.DailyBread
{
	[PresenterBinding(typeof(DailyBreadItemPresenter), ViewType = typeof(IDailyBreadDetailView))]
	public partial class Detail : BaseLogicPage<DailyBreadModel>, IDailyBreadDetailView
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				GetDailyBreadDetail(this, new EventArgs());
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

		}

		#endregion

		#region Implementation of IDailyBreadDetailView

		public event EventHandler GetDailyBreadDetail;
		public void BindDailyBreadDetail()
		{
			ltrTitle.Text = string.Format("<a href=\"{0}\">{1}</a>", Model.DailyBreadUrl, Model.DailyBreadTitle);
			ltrInfo.Text = Model.DatePublished.ToBuncisShortFormatString();
			ltrContent.Text = Model.DailyBreadContent;
			ltrBible.Text = Model.DailyBreadBible;
			ltrBibleContent.Text = Model.DailyBreadBibleContent;

			Page.Title = Model.DailyBreadTitle;
			Page.MetaDescription = Model.DailyBreadSummary;

			ltrSocial.Text = WebUtil.GetSocialBar(Model.DailyBreadUrl);

			WebUtil.PutFBOpenGraphMetaTag(Page, Model.DailyBreadTitle, Model.DailyBreadSummary, Model.DailyBreadUrl);
		}

		#endregion
	}
}