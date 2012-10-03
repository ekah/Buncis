using System;

namespace Buncis.Logic.CustomEventArgs
{
	public class NewsListEventArgs : EventArgs
	{
		public int ClientId { get; set; }
		public int CategoryId { get; set; }
	}
}
