using System;
using Buncis.Logic.Views;
using Buncis.Core.Services;
using Buncis.Web.Common.Utility;
using Buncis.Core.Resources;
using Omu.ValueInjecter;

namespace Buncis.Logic.Presenters
{
    public class DynamicPagePresenter : CorePresenter<IDynamicPageView>
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
