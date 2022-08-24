using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace Ecommerce.Utilities
{
    public static class FileHandler
    {
        public async static Task<T> Reader<T>(string location)
        {
            var fileContent = "";
            if (File.Exists(location))
            {
                fileContent = await File.ReadAllTextAsync(location);
            }
            else
            {
                File.Create(location).Dispose();
            }
            T resultObject = JsonConvert.DeserializeObject<T>(fileContent);
            T container = resultObject;
            return container;
        }
        public static void Writer<T>(string location, T content)
        {
            string fileContent = JsonConvert.SerializeObject(content);
            File.WriteAllTextAsync(location,fileContent).Dispose();
        }
    }
}
