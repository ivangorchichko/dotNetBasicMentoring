using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PluginInterface;
using Formatting = System.Xml.Formatting;

namespace CustomProviders
{
    public class FileConfigurationProvider : IProvider
    {
        public ProviderType ProviderType => ProviderType.FileManager;

        private const string FilePath = @"..\..\..\CustomFile.txt";
        private static readonly string JsonStringFromTxt = File.ReadAllText(FilePath);
        private static readonly JObject JsonObjFromTxt = JsonConvert.DeserializeObject<JObject>(JsonStringFromTxt);

        public object Read(string key)
        {
            if (JsonObjFromTxt != null)
            {
                return JsonObjFromTxt[key];
            }

            return null;
        }

        public void Write(string key, object value)
        {
            if (JsonObjFromTxt != null)
            {
                JsonObjFromTxt[key] = value.ToString();
            }

            string updatedJsonString = JsonConvert.SerializeObject(JsonObjFromTxt, (Newtonsoft.Json.Formatting)Formatting.Indented);
            File.WriteAllText(FilePath, updatedJsonString);
        }
    }
}