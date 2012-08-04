using System;
using WebFormsMvp;

namespace Buncis.Framework.Mvp.Views
{
    public interface ICustomEventView : IView
    {
        event EventHandler Initialize;
	}
}
