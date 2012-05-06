using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Buncis.Core.Utility.Logging
{
	public class BuncisLog : IBuncisLog
	{
		private string _logPath = @"d:\projects\buncis\buncis.log";

		public void WriteLog(string log)
		{
            //using (TextWriter tw = new StreamWriter(_logPath, true))
            //{
            //    tw.WriteLine(log);
            //    tw.Close();
            //}
		}
	}
}
