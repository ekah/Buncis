using System;
using System.Linq;

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
