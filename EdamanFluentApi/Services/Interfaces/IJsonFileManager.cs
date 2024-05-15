namespace EdamanFluentApi.Services.Interfaces
{
    public interface IJsonFileManager
    {
        bool JsonFileExists(string fileName, string folderPath, string cuisineType);
        T ReadFromJsonFile<T>(string fileName, string folderPath, string cuisineType);
        void WriteToJsonFile<T>(string fileName, string folderPath, string cuisineType, T data);
    }
}