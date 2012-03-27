using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Buncis.Logic.Models;
using Buncis.Logic.Presenters;
using Buncis.Logic.Views;
using WebFormsMvp;

namespace Buncis.Web
{
    [PresenterBinding(typeof(DynamicPagePresenter), ViewType = typeof(IDynamicPageView))]
    public partial class DynamicPage : BasePage<DynamicPageModel>, IDynamicPageView
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Initialize(this, e);
        }
        #region IBindableView<DynamicPageModel> Members

        public void BindViewData()
        {
            ltrBodyContent.Text = Model.PageContent;
        }

        #endregion

        #region IBaseView<DynamicPageModel> Members

        public event EventHandler Initialize;

        #endregion
    }
}
