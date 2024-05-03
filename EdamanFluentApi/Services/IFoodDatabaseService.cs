using EdamanFluentApi.Model.FoodDatabase;

namespace EdamanFluentApi.Services
{
    public interface IFoodDatabaseService
    {
        Task<List<Food>> RetrieveAllFoodItems(string query);
    }
}
