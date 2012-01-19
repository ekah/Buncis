using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel;

namespace Buncis.Framework.Core.Infrastructure.Settings
{
    public class SettingsProvider<TSettings> where TSettings : class, new()
    {
        private IPropertySettingsResolver _resolver;

        public SettingsProvider(IPropertySettingsResolver resolver)
        {
            _resolver = resolver;
        }

        public TSettings ResolveSettings()
        {
            TSettings instance = Activator.CreateInstance<TSettings>();
            Type type = instance.GetType();

            // use reflection to resolve each settings property from app config
            // possible to use interface so settings can be obtain from resource or app config
            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                var propertyName = property.Name.ToLower();
                object propertyValue = (object)_resolver.ResolvePropertySettings(propertyName);

                //TypeConverter typeConverter = TypeDescriptor.GetConverter(propertyValue.GetType());
                TypeConverter typeConverter = TypeDescriptor.GetConverter(property.PropertyType);
                if (typeConverter.CanConvertFrom(propertyValue.GetType()))
                {
                    object convertedPropertyValue = typeConverter.ConvertFrom(propertyValue);

                    property.SetValue(instance, convertedPropertyValue, null);
                }
            }

            return instance;
        }
    }
}
