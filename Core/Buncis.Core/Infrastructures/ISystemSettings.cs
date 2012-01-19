using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buncis.Core.Infrastructures
{
    public interface ISystemSettings
    {
        decimal PpnTax { get; set; }
        string DeveloperEmail { get; set; }
        int GlobalItemPerPage { get; set; }

    }
}
