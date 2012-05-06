using System.Web.UI;
using WebFormsMvp.Web;
using System;
using Buncis.Framework.Mvp.Views;

namespace Buncis.Web.Base
{
	public class BasePage<TModel> : MvpPage<TModel>, ICustomEventView where TModel : class, new()
	{
		public event EventHandler Initialize;

		protected void TriggerInitializeView(object sender, EventArgs e)
		{
			Initialize(sender, e);
		}
	}
}