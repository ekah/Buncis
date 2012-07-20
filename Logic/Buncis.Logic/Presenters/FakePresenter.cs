using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buncis.Framework.Mvp.Presenters;
using Buncis.Framework.Mvp.Views;
using Buncis.Logic.Views;

namespace Buncis.Logic.Presenters
{
	public class FakePresenter : BasePresenter<IFakeView>
	{
		public FakePresenter(IFakeView view)
			: base(view)
		{
		}
	}
}
