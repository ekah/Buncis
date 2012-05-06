using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace Buncis.Web.Common.DynamicControls
{
    public interface IDynamicControlsResolver
    {
        void ResolveDynamicControls(Control controlToAddResult, string pageContent);
    }
}
