using System;
using PluginInterface;
using Reflection.CustomAttribute;

namespace Reflection.AttributeUsage
{
    public class ConfigSettings : ConfigurationComponentBase
    {
        [ConfigurationItemAttribute(ProviderType.ConfigurationManager, "DaysCount")]
        public int? IntValue
        {
            get
            {
                var value = LoadSetting(nameof(IntValue));
                if (value != null && int.TryParse(value.ToString(), out int intValue))
                {
                    return intValue;
                }
                return null;
            }

            set => SaveSetting(nameof(IntValue), value);
        }

        [ConfigurationItemAttribute(ProviderType.ConfigurationManager, "Curse")]
        public float? FloatValue
        {
            get
            {
                var value = LoadSetting(nameof(FloatValue));
                if (value != null && float.TryParse(value.ToString(), out float floatValue))
                {
                    return floatValue;
                }
                return null;
            }

            set => SaveSetting(nameof(FloatValue), value);
        }

        [ConfigurationItemAttribute(ProviderType.ConfigurationManager, "DatabaseName")]
        public string StringValue
        {
            get
            {
                var value = LoadSetting(nameof(StringValue));
                if (value != null)
                {
                    return value.ToString();
                }
                return null;
            }

            set => SaveSetting(nameof(StringValue), value);
        }

        [ConfigurationItemAttribute(ProviderType.ConfigurationManager, "Timeout")]
        public TimeSpan? TimeSpanValue
        {
            get
            {
                var value = LoadSetting(nameof(TimeSpanValue));
                if (value != null && TimeSpan.TryParse(value.ToString(), out TimeSpan timeSpanValue))
                {
                    return timeSpanValue;
                }
                return null;
            }

            set => SaveSetting(nameof(TimeSpanValue), value);
        }
    }
}
