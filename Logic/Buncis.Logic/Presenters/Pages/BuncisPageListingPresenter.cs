using System;
using System.Linq;
using Buncis.Logic.Views.Pages;
using Buncis.Logic.ViewModel;
using Omu.ValueInjecter;
using Buncis.Framework.Services.Pages;

namespace Buncis.Logic.Presenters.Pages
{
    public class BuncisPageListingPresenter : LogicPresenter<IBuncisPageListingView>
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
            }).ToList();

            convertedPages = convertedPages.OrderByDescending(o => o.IsHomePage).ThenBy(o => o.PageName).ToList();

            this.View.Model.BuncisPages = convertedPages;

            this.View.BindViewData();
        }
    }
}
