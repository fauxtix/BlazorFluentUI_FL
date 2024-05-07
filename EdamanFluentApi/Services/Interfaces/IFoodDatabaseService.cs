using EdamanFluentApi.Model.FoodDatabase;

namespace EdamanFluentApi.Services.Interfaces
{
    public interface IFoodDatabaseService
    {
        Task<List<Food>> RetrieveAllFoodItems(string query);
    }
}
