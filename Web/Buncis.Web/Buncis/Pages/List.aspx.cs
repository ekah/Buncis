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
using Buncis.Logic.ViewModel;

namespace Buncis.Web.Buncis.Pages
{
    [PresenterBinding(typeof(BuncisPageListingPresenter), ViewType = typeof(IBuncisPageListingView))]
    public partial class List : BasePage<BuncisPageListingModel>, IBuncisPageListingView
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            SetupPageHandlers();
        }

        private void SetupPageHandlers()
        {
            rptPages.ItemDataBound += new RepeaterItemEventHandler(rptPages_ItemDataBound);
        }

        void rptPages_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var dataItem = (BuncisPageViewModel)e.Item.DataItem;
                var spanIcon = e.Item.FindControl("spanIcon") as HtmlGenericControl;
                spanIcon.Attributes["class"] = dataItem.IsHomePage
                    ? "icon icon-home"
                    : "icon icon-pages";
            }
        }

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