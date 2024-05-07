using EdamanFluentApi.Models.Recipes;
using System.Collections.ObjectModel;

namespace EdamanFluentApi.Services.Interfaces
{
    public interface IRecipesService
    {
        List<string> GetJsonFiles();
        Task<ObservableCollection<Recipe>> SearchRecipes(string ingredient, string diet, string allergie, string limit="");
    }
}