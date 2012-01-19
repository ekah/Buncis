using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buncis.Framework.Core.Infrastructure.Settings
{
    public interface IPropertySettingsResolver
    {
        string ResolvePropertySettings(string keyName);
    }
}
