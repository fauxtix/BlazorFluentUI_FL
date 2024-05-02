using EdamanFluentApi.Model;
using EdamanFluentApi.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.FluentUI.AspNetCore.Components;
using System.Collections.ObjectModel;

namespace EdamanFluentApi.Components.Pages
{
    public partial class Home
    {
        [Inject] public IRecipesService? recipeService { get; set; }
        protected ObservableCollection<Recipe> recipes = new();
        protected string recipeUrl = string.Empty;
        protected string? SelectedItem { get; set; }
        protected FluentSearch searchQuery;
        private string searchValue = string.Empty;
        protected bool isLoading = false;

        private string SearchValue
        {
            get => searchValue;
            set
            {
                if (value != searchValue)
                {
                    searchValue = value;
                }
            }
        }

        protected override void OnInitialized()
        {
            recipes = new();
        }

        protected async void OnSearch(MouseEventArgs args)
        {
            recipes.Clear();
            recipes = await GetRecipes(SearchValue);
            if (recipes.Count == 0)
            {
                ShowToast($"No records found for {SearchValue}");
            }
            StateHasChanged();
        }

        protected async Task<ObservableCollection<Recipe>> GetRecipes(string query)
        {
            isLoading = true;
            var output = await recipeService.SearchRecipes(query, "", "");
            isLoading = false;
            return output;
        }

        private void ShowToast(string message)
        {
            ToastService.ShowWarning(message, 2000);
        }

        private void HandleClear()
        {
            if (string.IsNullOrWhiteSpace(SearchValue))
                return;

            SearchValue = string.Empty;
            StateHasChanged();
        }
    }
}