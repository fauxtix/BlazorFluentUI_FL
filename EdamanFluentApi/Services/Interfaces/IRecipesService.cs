using EdamanFluentApi.Models.Recipes;
using System.Collections.ObjectModel;

namespace EdamanFluentApi.Services.Interfaces
{
    public interface IRecipesService
    {
        Task<ObservableCollection<Recipe>> SearchRecipes(string ingredient, string diet, string allergie);
    }
}