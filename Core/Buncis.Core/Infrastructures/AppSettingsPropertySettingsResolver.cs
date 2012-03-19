using System.Configuration;
using Buncis.Framework.Core.Infrastructure.Settings;

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