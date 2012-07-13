using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buncis.Framework.Infrastructure.Extensions;

namespace Buncis.Framework.Core.ViewModel
{
	public class vBuncisNews
	{
		public int NewsId { get; set; }
		public string NewsTitle { get; set; }
		public string NewsTeaser { get; set; }
		public string NewsContent { get; set; }
		public DateTime DatePublished { get; set; }
		public string DisplayDatePublished
		{
			get
			{
				return DatePublished.ToLongFormatString();
			}
		}
		public DateTime DateExpired { get; set; }
		public string DisplayDateExpired
		{
			get
			{
				return DateExpired.ToLongFormatString();
			}
		}
		public string FriendlyUrl { get; set; }
		public DateTime DateCreated { get; set; }
		public string DisplayDateCreated
		{
			get
			{
				return DateCreated.ToLongFormatString();
			}
		}
		public DateTime DateLastUpdated { get; set; }
		public string DisplayDateLastUpdated
		{
			get
			{
				return DateLastUpdated.ToLongFormatString();
			}
		}
	}
}
