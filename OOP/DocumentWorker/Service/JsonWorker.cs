using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using DocumentWorker.DocTypeModel;
using DocumentWorker.Interfaces;

namespace DocumentWorker.Service
{
    public class JsonWorker : IJsonFileWorker
    {
        public void Write<T>(IEnumerable<T> documents) where T : BaseDoc
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            foreach (var document in documents)
            {
                var jsonString = JsonSerializer.Serialize(document, options);
                File.WriteAllText($"{typeof(T).Name}_#{{{document.Id}}}.json", jsonString);
            }
        }

        public T Read<T>(int documentNumber) where T : BaseDoc
        {
            var directory = new DirectoryInfo(Directory.GetCurrentDirectory());
            var files = directory
                .GetFiles("*.json")
                .Where(x => x.Name.StartsWith(typeof(T).Name));

            foreach (var file in files)
            {
                var jsonString = File.ReadAllText(file.FullName);
                var document = JsonSerializer.Deserialize<T>(jsonString)!;
                if (document.Id == documentNumber)
                    return document;
            }
            return null;
        }
    }
}
