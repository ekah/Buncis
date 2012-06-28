using System;
using System.Linq;
using Buncis.Framework.Core.Services.Pages;
using Buncis.Logic.Views.Pages;
using Buncis.Framework.Mvp.Presenters;
using System.Collections.Generic;

namespace Buncis.Logic.Presenters.Pages
{
    public class BuncisPageListingPresenter : LogicPresenter<IBuncisPageListingView>
    {
        private readonly IDynamicPageService _dynamicPageService;

        public BuncisPageListingPresenter(IBuncisPageListingView view, IDynamicPageService dynamicPageService)
            : base(view)
        {
            _dynamicPageService = dynamicPageService;
        }
    }
}
