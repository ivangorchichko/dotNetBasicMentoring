using System;
using System.Configuration;
using PluginInterface;

namespace CustomProviders
{
    public class ConfigurationManagerProvider : IProvider
    {
        public ProviderType ProviderType => ProviderType.ConfigurationManager;

        public object Read(string foundKey)
        {
            var appSettings = ConfigurationManager.AppSettings;

            if (appSettings.Count == 0)
            {
                Console.WriteLine("AppSettings is empty.");
            }
            else
            {
                return appSettings[foundKey] ?? "Not Found";
            }

            return null;
        }

        //Changes saves to ..\Reflection\Reflection\bin\Debug\netcoreapp3.1\Reflection.dll.config file
        public void Write(string key, object value)
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;
            if (settings[key] == null)
            {
                settings.Add(key, value.ToString());
            }
            else
            {
                settings[key].Value = value.ToString();
            }
            configFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}