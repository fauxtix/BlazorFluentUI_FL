namespace EdamanFluentApi.Services.Interfaces
{
    public interface IJsonFileManager
    {
        bool JsonFileExists(string filePath);
        bool JsonFileExists(string fileName, string folderPath);
        T ReadFromJsonFile<T>(string filePath);
        T ReadFromJsonFile<T>(string fileName, string folderPath);
        void WriteToJsonFile<T>(string filePath, T data);
        void WriteToJsonFile<T>(string fileName, string folderPath, T data);
    }
}