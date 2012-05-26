using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buncis.Logic.Views.Pages;
using Buncis.Core.Services;
using Buncis.Core.Services.Pages;
using Buncis.Logic.ViewModel;
using Omu.ValueInjecter;

namespace Buncis.Logic.Presenters.Pages
{
    public class BuncisPageListingPresenter : CorePresenter<IBuncisPageListingView>
    {
        private readonly IDynamicPageService _dynamicPageService;

        public BuncisPageListingPresenter(IBuncisPageListingView view, IDynamicPageService dynamicPageService)
            : base(view)
        {
            _dynamicPageService = dynamicPageService;

            this.View.GetList += new EventHandler(View_GetList);
        }

        void View_GetList(object sender, EventArgs e)
        {
            var rawPages = _dynamicPageService.GetPagesNotDeleted();
            var convertedPages = rawPages.Select(o =>
            {
                var viewModel = new BuncisPageViewModel();
                viewModel.InjectFrom(o);

                return viewModel;
            }).ToList().AsEnumerable();

            this.View.Model.BuncisPages = convertedPages;

            this.View.BindViewData();
        }
    }
}
