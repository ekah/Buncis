using System;
using Buncis.Framework.Core.Services.Pages;
using Buncis.Framework.Core.ViewModel;
using Buncis.Web.Common.Utility;
using Omu.ValueInjecter;
using Buncis.Logic.Views.Pages;
using Buncis.Framework.Core.Resources;
using Buncis.Web.Common.Exceptions;

namespace Buncis.Logic.Presenters.Pages
{
	public class DynamicPagePresenter : LogicPresenter<IDynamicPageView>
	{
		private readonly IDynamicPageService _dynamicPageService;

		public DynamicPagePresenter(IDynamicPageView view, IDynamicPageService dynamicPageService)
			: base(view)
		{
			_dynamicPageService = dynamicPageService;
		}

		protected override void view_Initialize(object sender, EventArgs e)
		{
			var pageId = int.Parse(WebUtil.GetQueryString(QueryStrings.PageId, "-1"));
			var pageFromDb = _dynamicPageService.GetPage(pageId);
			if (pageFromDb == null)
			{
				throw new PageNotFoundException("The Page is not found in database", pageId);
			}
			
			View.Model.PageId = pageFromDb.PageId;
			View.Model.MetaTitle = pageFromDb.MetaTitle;
			View.Model.MetaDescription = pageFromDb.MetaDescription;
			View.Model.PageContent = pageFromDb.PageContent;
			View.BindViewData();
		}
	}
}
