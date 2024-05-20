using EdamanFluentApi.Model.FoodDatabase;

namespace EdamanFluentApi.Services.Interfaces.Edaman
{
    public interface IFoodDatabaseService
    {
        Task<List<Food>> RetrieveAllFoodItems(string query);
    }
}
