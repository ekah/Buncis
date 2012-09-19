using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buncis.Framework.Core.ViewModel
{
	public class ViewModelBuncisNewsCategory
	{
		public int NewsCategoryId { get; set; }
		public string NewsCategoryName { get; set; }
		public string NewsCategoryDescription { get; set; }
		public DateTime DateCreated { get; set; }
		public DateTime DateLastUpdated { get; set; }
	}
}
