using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buncis.Framework.Core.ViewModel;

namespace Buncis.Logic.Models.DailyBread
{
	public class DailyBreadListModel
	{
		public IEnumerable<ViewModelDailyBreadItem> DailyBreadItems { get; set; }
	}
}
