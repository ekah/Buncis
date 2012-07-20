using System;
using System.Linq;
using System.Web.UI.WebControls;
using Buncis.Logic.Models;
using Buncis.Logic.Presenters;
using Buncis.Logic.Views;
using Buncis.Logic.Views.Pages;
using Buncis.Logic.Models.Pages;
using Buncis.Web.Base;
using Buncis.Logic.Presenters.Pages;
using WebFormsMvp;
using Buncis.Logic.CustomEventArgs;
using System.Web.UI.HtmlControls;

namespace Buncis.Web.bPanel.Pages
{
	[PresenterBinding(typeof(FakePresenter), ViewType = typeof(IFakeView))]
	public partial class List : BaseLogicPage<FakeModel>, IFakeView
	{
		public void BindViewData()
		{

		}
	}
}