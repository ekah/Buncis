using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebFormsMvp;

namespace Buncis.Framework.Mvp.Views
{
	public interface ICustomEventView : IView
	{
		event EventHandler Initialize;
	}
}
