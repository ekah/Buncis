using System;
using System.Linq;
using System.Web.UI;

namespace Buncis.Web.Common.DynamicControls
{
    public interface IDynamicControlsResolver
    {
        void ResolveDynamicControls(Control controlToAddResult, string pageContent);
    }
}
