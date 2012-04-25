using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buncis.Logic.Views;
using Buncis.Core.Services;
using Buncis.Web.Common.Utility;
using Buncis.Core.Resources;

namespace Buncis.Logic.Presenters
{
    public class DynamicPagePresenter : BuncisBasePresenter<IDynamicPageView>
    {
        private IDynamicPageService _dynamicPageService;

        public DynamicPagePresenter(IDynamicPageView view, IDynamicPageService dynamicPageService)
            : base(view)
        {
            _dynamicPageService = dynamicPageService;

            view.Initialize += view_Initialize;
        }

        void view_Initialize(object sender, EventArgs e)
        {
            
        }

        protected override void view_Load(object sender, EventArgs e)
        {
            var pageId = int.Parse(WebUtil.GetQueryString(QueryStrings.PageId, "-1"));
            var pageFromDb = _dynamicPageService.GetPage(pageId);

            if (pageFromDb == null)
            {
                throw new Exception("The Page is not found in database");
            }

            View.Model.PageContent = pageFromDb.PageContent;
            View.BindViewData();
        }
    }
}
