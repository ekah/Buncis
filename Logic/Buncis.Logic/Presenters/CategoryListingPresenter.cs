using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buncis.Logic.Views;
using Buncis.Framework.Mvp.Presenters;
using Buncis.Core.Infrastructures;

namespace Buncis.Logic.Presenters
{
    public class CategoryListingPresenter : BuncisBasePresenter<ICategoryListingView>
    {
        public CategoryListingPresenter(ISystemSettings systemSettings, ICategoryListingView view)
            : base(systemSettings, view)
        {

        }
    }
}
