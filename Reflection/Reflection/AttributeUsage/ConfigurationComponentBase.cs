using System;
using PluginInterface;
using Reflection.CustomAttribute;
using Reflection.Service;

namespace Reflection.AttributeUsage
{
    public class ConfigurationComponentBase
    {
        private static IProvider _provider;

        public object LoadSetting(string propertyName)
        {
            var attribute = GetAttribute(propertyName);

            if (attribute != null)
            {
                _provider = ProvidersLoader.GetProvider(attribute.Type);
                var value = _provider.Read(attribute.SettingName);

                return value;
            }

            return null;
        }

        public void SaveSetting(string propertyName, object value)
        {
            var attribute = GetAttribute(propertyName);
            if (attribute != null)
            {
                _provider = ProvidersLoader.GetProvider(attribute.Type);
                _provider.Write(attribute.SettingName, value);
            }
        }

        private ConfigurationItemAttribute GetAttribute(string propertyName)
        {
            var property = GetType().GetProperty(propertyName);

            if (property != null)
            {
                return Attribute.GetCustomAttribute(property, typeof(ConfigurationItemAttribute))
                    as ConfigurationItemAttribute; ;
            }

            return null;
        }
    }
}
