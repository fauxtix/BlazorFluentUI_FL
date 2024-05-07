namespace EdamanFluentApi.Services.Interfaces
{
    public interface IAutoCompleteFoodDatabaseService
    {
        Task<List<string>> RetrieveAutoCompleteItems(string query);
    }
}
