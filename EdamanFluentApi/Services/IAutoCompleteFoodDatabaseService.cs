namespace EdamanFluentApi.Services
{
    public interface IAutoCompleteFoodDatabaseService
    {
        Task<List<string>> RetrieveAutoCompleteItems(string query);
    }
}
