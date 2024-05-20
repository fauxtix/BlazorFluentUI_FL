namespace EdamanFluentApi.Services.Interfaces.Edaman
{
    public interface IAutoCompleteFoodDatabaseService
    {
        Task<List<string>> RetrieveAutoCompleteItems(string query);
    }
}
