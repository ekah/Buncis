using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buncis.Logic.DataTransferObject
{
	public class oBuncisNews
	{
		public int NewsId { get; set; }
		public string NewsTitle { get; set; }
		public string NewsTeaser { get; set; }
		public string NewsContent { get; set; }
		public string DisplayDateCreated { get; set; }
		public string DisplayDatePublished { get; set; }
		public string DisplayDateExpired { get; set; }
		public string FriendlyUrl { get; set; }
		public DateTime DateCreated { get; set; }
		public DateTime DateLastUpdated { get; set; }
	}
}
