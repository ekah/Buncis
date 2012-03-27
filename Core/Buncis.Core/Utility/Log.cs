using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Buncis.Core.Utility
{
    public class Log
    {
        private string _logPath = @"d:\projects\buncis\buncis.log";

        public void SaveToText(string textToLog)
        {
            using (TextWriter tw = new StreamWriter(_logPath, true))
            {
                tw.WriteLine(textToLog);
                tw.Close();
            }
        }
    }
}
