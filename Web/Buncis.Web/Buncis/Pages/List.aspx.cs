using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Buncis.Logic.Views.Pages;
using Buncis.Logic.Models.Pages;
using Buncis.Web.Base;
using Buncis.Logic.Presenters.Pages;
using WebFormsMvp;
using Buncis.Logic.CustomEventArgs;

namespace Buncis.Web.Buncis.Pages
{
    [PresenterBinding(typeof(BuncisPageListingPresenter), ViewType = typeof(IBuncisPageListingView))]
    public partial class List : BasePage<BuncisPageListingModel>, IBuncisPageListingView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (GetList != null)
                {
                    GetList(this, new BuncisPageListingEventArgs());
                }
            }
        }

        public event EventHandler GetList;

        public void BindViewData()
        {
            rptPages.DataSource = Model.BuncisPages;
            rptPages.DataBind();
        }
    }
}