using EdamanFluentApi.Models.Recipes;
using System.Collections.ObjectModel;

namespace EdamanFluentApi.Services.Interfaces.Edaman
{
    public interface IRecipesService
    {
        List<string> GetCuisineTypes();
        List<string> GetJsonFiles(string cuisineType = "");
        Task<ObservableCollection<Recipe>> SearchRecipes(string ingredient, string diet, string allergie, string limit = "", string cuisineType = "");
    }
}