using System;
using WebFormsMvp;
using Buncis.Framework.Mvp.Presenters;

namespace Buncis.Framework.Mvp.Views
{
    public interface ICustomEventView : IView
    {
        event EventHandler Initialize;
	}
}
