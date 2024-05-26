using EdamanFluentApi.Models.Recipes;
using EdamanFluentApi.Services.Interfaces.Edaman;
using Newtonsoft.Json;

namespace EdamanFluentApi.Services.Implementations.Edaman
{
    public class JsonFileManager : IJsonFileManager
    {
        public void WriteToJsonFile<T>(string fileName, string folderPath, string cuisineType, T data)
        {
            string filePath;
            if (string.IsNullOrEmpty(cuisineType))
            {
                cuisineType = "General";
                int closingParenthesisIndex = fileName.IndexOf(')');
                if (closingParenthesisIndex != -1)
                {
                    fileName = fileName.Substring(closingParenthesisIndex + 2);
                }
            }
            filePath = Path.Combine(folderPath, cuisineType, fileName);
            string directoryName = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(directoryName))
            {
                Directory.CreateDirectory(directoryName);
            }
            string json = JsonConvert.SerializeObject(data);
            File.WriteAllText(filePath, json);
        }

        public T ReadFromJsonFile<T>(string fileName, string folderPath, string cuisineType)
        {
            if (string.IsNullOrEmpty(cuisineType))
            {
                var strippedFilename = StripFileNameAndCuisineType(fileName);
                cuisineType = strippedFilename.type;
                fileName = strippedFilename.filename;
            }
            string filePath = Path.Combine(folderPath, cuisineType, fileName);
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<T>(json);
        }

        public bool JsonFileExists(string fileName, string folderPath, string cuisineType)
        {
            var strippedFilename = StripFileNameAndCuisineType(fileName);

            if (string.IsNullOrEmpty(cuisineType))
                cuisineType = strippedFilename.type;

            fileName = strippedFilename.filename;

            string filePath = Path.Combine(folderPath, cuisineType, fileName);
            return File.Exists(filePath);
        }

        private (string filename, string type) StripFileNameAndCuisineType(string fileName)
        {
            string cuisineType = "";
            int openingParenthesisIndex = fileName.IndexOf('(');
            if (openingParenthesisIndex >= 0)
            {
                int closingParenthesisIndex = fileName.IndexOf(')');
                cuisineType = fileName.Substring(openingParenthesisIndex + 1, closingParenthesisIndex - openingParenthesisIndex - 1);

                int closingfFileNameParenthesisIndex = fileName.IndexOf(')');
                fileName = fileName.Substring(closingfFileNameParenthesisIndex + 2);
            }
            else
            {
                cuisineType = "General";
            }
            return (fileName, cuisineType);

        }
    }
}
