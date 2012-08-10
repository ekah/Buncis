using System;
using System.Linq;
using Buncis.Framework.Core.Infrastructure.IoC;
using Buncis.Web.Base;
using WebFormsMvp;
using Buncis.Web.Common.DynamicControls;
using Buncis.Logic.Models.Pages;
using Buncis.Logic.Views.Pages;
using Buncis.Logic.Presenters.Pages;
using Buncis.Web.Common.Exceptions;

namespace Buncis.Web
{
	[PresenterBinding(typeof(DynamicPagePresenter), ViewType = typeof(IDynamicPageView))]
	public partial class DynamicLogicPage : BaseLogicPage<DynamicPageModel>, IDynamicPageView
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				InitializeView();
			}
			catch (PageNotFoundException pnfex)
			{
				Response.StatusCode = 404;
			}
			catch (Exception ex)
			{
				// for now remove all error to 404
				Response.StatusCode = 404;
			}
		}

		#region IBindableView<DynamicPageModel> Members

		public void BindViewData()
		{
			Page.Title = Model.DynamicPage.MetaTitle;
			Page.MetaDescription = Model.DynamicPage.MetaDescription;

			var controlResolver = IoC.Resolve<IDynamicControlsResolver>();
			controlResolver.ResolveDynamicControls(plcBodyContent, Model.DynamicPage.PageContent);
		}

		#endregion

	}
}
