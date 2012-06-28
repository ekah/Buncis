using System;
using System.Linq;
using System.Web.UI.WebControls;
using Buncis.Logic.Views.Pages;
using Buncis.Logic.Models.Pages;
using Buncis.Web.Base;
using Buncis.Logic.Presenters.Pages;
using WebFormsMvp;
using Buncis.Logic.CustomEventArgs;
using System.Web.UI.HtmlControls;

namespace Buncis.Web.bPanel.Pages
{
    [PresenterBinding(typeof(BuncisPageListingPresenter), ViewType = typeof(IBuncisPageListingView))]
    public partial class List : BaseLogicPage<BuncisPageListingModel>, IBuncisPageListingView
    {
        public void BindViewData()
        {
            throw new NotImplementedException();
        }
    }
}