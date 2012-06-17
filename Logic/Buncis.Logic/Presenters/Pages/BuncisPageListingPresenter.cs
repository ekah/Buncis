using System;
using System.Linq;
using Buncis.Logic.Views.Pages;
using Buncis.Logic.ViewModel;
using Buncis.Framework.Services.Pages;
using Buncis.Framework.Mvp.Presenters;
using System.Collections.Generic;
using Buncis.Logic.BusinessObject;

namespace Buncis.Logic.Presenters.Pages
{
    public class BuncisPageListingPresenter : LogicPresenter<IBuncisPageListingView>
    {
        private readonly IDynamicPageService _dynamicPageService;
        private readonly BuncisPages _buncisPages;

        public BuncisPageListingPresenter(IBuncisPageListingView view, IDynamicPageService dynamicPageService)
            : base(view)
        {
            _dynamicPageService = dynamicPageService;
            _buncisPages = new BuncisPages(_dynamicPageService);
        }

    }
}
