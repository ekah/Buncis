using System.Configuration;

namespace Buncis.Framework.Core.Infrastructure.Settings
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