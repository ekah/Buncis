﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buncis.Logic.CustomEventArgs
{
	public class DailyBreadListEventArgs : EventArgs
	{
		public int ClientId { get; set; }
	}
}