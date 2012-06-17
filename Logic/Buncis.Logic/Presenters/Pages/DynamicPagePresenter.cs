using System;
using Buncis.Web.Common.Utility;
using Omu.ValueInjecter;
using Buncis.Logic.Views.Pages;
using Buncis.Framework.Services.Pages;
using Buncis.Framework.Core.Resources;

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

        protected override void view_Load(object sender, EventArgs e)
        {
            var pageId = int.Parse(WebUtil.GetQueryString(QueryStrings.PageId, "-1"));
            var pageFromDb = _dynamicPageService.GetPage(pageId);
            if (pageFromDb == null)
            {
                throw new Exception("The Page is not found in database");
            }

            View.Model.InjectFrom(pageFromDb);
            View.BindViewData();
        }
    }
}
