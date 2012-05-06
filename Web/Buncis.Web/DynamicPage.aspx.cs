using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Buncis.Framework.Core.Infrastructure.IoC;
using Buncis.Logic.Models;
using Buncis.Logic.Presenters;
using Buncis.Logic.Views;
using Buncis.Web.Base;
using WebFormsMvp;

namespace Buncis.Web
{
	[PresenterBinding(typeof(DynamicPagePresenter), ViewType = typeof(IDynamicPageView))]
	public partial class DynamicPage : BasePage<DynamicPageModel>, IDynamicPageView
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			TriggerInitializeView(this, e);
		}

		#region IBindableView<DynamicPageModel> Members

		public void BindViewData()
		{
			var rawPageContent = Model.PageContent;

			
		}

		#endregion

	}
}
