using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buncis.Web.Common.DynamicControls
{
    public class DynamicControl
    {
        // todo: probably can change the key to Guid
        public string ControlKey { get; set; }
        public string RenderTag { get; set; }
        public string ControlPath { get; set; }
    }
}
