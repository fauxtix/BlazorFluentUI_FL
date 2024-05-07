using EdamanFluentApi.Services.Interfaces;
using Newtonsoft.Json;

namespace EdamanFluentApi.Services.Implementations
{
    public class JsonFileManager : IJsonFileManager
    {
        private readonly string _folderPath;
        public JsonFileManager(IWebHostEnvironment environment)
        {
            _folderPath = Path.Combine(environment.WebRootPath, "JsonFiles");

            if (!Directory.Exists(_folderPath))
            {
                Directory.CreateDirectory(_folderPath);
            }
        }
        public void WriteToJsonFile<T>(string filePath, T data)
        {
            string json = JsonConvert.SerializeObject(data);
            File.WriteAllText(filePath, json);
        }

        public T ReadFromJsonFile<T>(string filePath)
        {
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<T>(json);
        }

        public void WriteToJsonFile<T>(string fileName, string folderPath, T data)
        {
            string filePath = Path.Combine(folderPath, fileName);
            string json = JsonConvert.SerializeObject(data);
            File.WriteAllText(filePath, json);
        }

        public T ReadFromJsonFile<T>(string fileName, string folderPath)
        {
            string filePath = Path.Combine(folderPath, fileName);
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<T>(json);
        }

        public bool JsonFileExists(string filePath)
        {
            return File.Exists(filePath);
        }

        public bool JsonFileExists(string fileName, string folderPath)
        {
            string filePath = Path.Combine(folderPath, fileName);
            return File.Exists(filePath);
        }
    }
}
