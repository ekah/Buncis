using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buncis.Framework.Core.Infrastructure.Settings;
using System.Configuration;

namespace Buncis.Core.Infrastructures
{
    public class AppSettingsPropertySettingsResolver : IPropertySettingsResolver
    {
        #region IPropertySettingsResolver Members

        public string ResolvePropertySettings(string keyName)
        {
            return ConfigurationManager.AppSettings[keyName];
        }

        #endregion
    }
}
