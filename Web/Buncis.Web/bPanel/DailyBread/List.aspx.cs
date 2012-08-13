using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Buncis.Logic.Models;
using Buncis.Logic.Presenters;
using Buncis.Web.Base;
using Buncis.Logic.Views;
using WebFormsMvp;

namespace Buncis.Web.bPanel.DailyBread
{
    [PresenterBinding(typeof(FakePresenter), ViewType = typeof(IFakeView))]
    public partial class List : BaseLogicPage<FakeModel>, IFakeView
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}
