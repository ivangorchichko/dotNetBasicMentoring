using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using PluginInterface;

namespace Reflection.Service
{
    public static class ProvidersLoader
    {
        public static IProvider GetProvider(ProviderType type)
        {
            var providers = LoadProviders();
            return providers.FirstOrDefault(p => p.ProviderType == type);
        }

        private static IEnumerable<IProvider> LoadProviders()
        {
            var providers = new List<IProvider>();

            foreach (var file in Directory.GetFiles(@"..\..\..\Plugins", "*.dll"))
            {
                var a = Directory.GetCurrentDirectory() + file;
                var asm = Assembly.LoadFrom(file);
                foreach (var type in asm.GetTypes())
                {
                    if (type.GetInterfaces().Contains(typeof(IProvider)))
                    {
                        var provider = Activator.CreateInstance(type) as IProvider;
                        providers.Add(provider);
                    }
                }
            }

            return providers;
        }
    }
}
