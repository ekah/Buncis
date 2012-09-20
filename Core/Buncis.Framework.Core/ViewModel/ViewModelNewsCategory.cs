using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buncis.Framework.Core.Infrastructure.Extensions;

namespace Buncis.Framework.Core.ViewModel
{
	public class ViewModelNewsCategory
	{
		public int NewsCategoryId { get; set; }
		public string NewsCategoryName { get; set; }
		public string NewsCategoryDescription { get; set; }
		public DateTime DateCreated { get; set; }
		public string DisplayDateCreated
		{
			get
			{
				return DateCreated.ToBuncisLongFormatString();
			}
		}	
		public DateTime DateLastUpdated { get; set; }
		public string DisplayDateLastUpdated
		{
			get
			{
				return DateLastUpdated.ToBuncisLongFormatString();
			}
		}
	}
}
