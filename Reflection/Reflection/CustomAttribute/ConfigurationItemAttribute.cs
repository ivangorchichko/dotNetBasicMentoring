using System;
using PluginInterface;

namespace Reflection.CustomAttribute
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ConfigurationItemAttribute : Attribute
    {
        public ConfigurationItemAttribute(ProviderType type, string settingName)
        {
            Type = type;
            SettingName = settingName;
        }

        public ProviderType Type { get; }

        public string SettingName { get; }
    }
}
