namespace Buncis.Framework.Core.Infrastructure.Settings
{
    public interface IPropertySettingsResolver
    {
        string ResolvePropertySettings(string keyName);
    }
}