using EdamanFluentApi.Models.Recipes;
using EdamanFluentApi.Services.Interfaces.Edaman;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.FluentUI.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.ObjectModel;

namespace EdamanFluentApi.Components.Pages.Edaman
{
    public partial class Recipes
    {
        [Inject] IJSRuntime JSRuntime { get; set; }
        [Inject] public IRecipesService recipeService { get; set; }
        [Inject] public ILogger<App> Logger { get; set; }
        [Inject] IConfiguration _config { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] IJsonFileManager _jsonFileManager { get; set; }
        [Inject] IDialogService DialogService{ get; set; }
        [Inject] IWebHostEnvironment _environment { get; set; }
       
        protected ObservableCollection<Recipe> recipes = new();
        protected List<string> cuisineTypes = new();
        protected string recipeUrl = string.Empty;
        protected string SelectedItem { get; set; } = string.Empty;
        protected FluentSearch searchQuery;
        private string searchValue = string.Empty;
        private int maxTries;
        private string configMaxTries;
        protected bool isLoading = false;
        protected List<string> jsonFiles = new();
        protected List<CuisineType> cuisines = new();
        protected string selectedCuisineType = string.Empty;
        protected bool selectedSavedSearch = false;

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
            jsonFiles = recipeService.GetJsonFiles();
            configMaxTries = _config["EdamanAPISettings:Recipes:TO_LIMIT"];
            maxTries = 25; // default
            cuisineTypes.Clear();
            cuisineTypes.Add("All");
            cuisineTypes.AddRange(recipeService.GetCuisineTypes());
        }

        protected void RefreshPage()
        {
            NavigationManager.NavigateTo(NavigationManager.Uri, forceLoad: true);
        }
        private async void ScrollTop()
        {
            await JSRuntime.InvokeVoidAsync("scrollToTop");
        }
        protected async void OnSearch(MouseEventArgs args)
        {
            if (string.IsNullOrEmpty(SearchValue))
            {
                ShowToast("Please fill the recipe(s) to search");
                return;
            }

            recipes.Clear();
            try
            {
                recipes = await GetRecipes(SearchValue);
                if (recipes is null || recipes.Count == 0)
                {
                    ShowToast($"No records found for {SearchValue}");
                }
                StateHasChanged();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message, ex);
                ShowToast(ex.Message);
            }
        }

        protected async Task<ObservableCollection<Recipe>> GetRecipes(string query)
        {
            try
            {
                isLoading = true;
                var output = await recipeService.SearchRecipes(query, "", "", maxTries.ToString(), selectedCuisineType);
                isLoading = false;

                string folderPath = Path.Combine(_environment.WebRootPath, "JsonFiles");

                var fileName = $"{query}.json";
                bool fileExists = _jsonFileManager.JsonFileExists(fileName, folderPath, selectedCuisineType);
                if (!fileExists)
                {
                    var title = "Edaman Recipes search";
                    var dialog = await DialogService.ShowConfirmationAsync("Save in 'Favorites'?", "Yes", "No", title);
                    var result = await dialog.Result;
                    var canceled = result.Cancelled;
                    if (!canceled)
                    {
                        SaveToJsonFile(fileName, folderPath, selectedCuisineType, output);

                    }
                }

                return output;

            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message, ex);
                ShowToast(ex.Message);
                return [];
            }
        }

        private void SaveToJsonFile(string fileName, string folderPath, string cuisineType, ObservableCollection<Recipe> recipes)
        {
            _jsonFileManager.WriteToJsonFile(fileName, folderPath, cuisineType, recipes);
        }

        private void OnSavedSearchesSelected(ChangeEventArgs args)
        {
            selectedSavedSearch = true;
            searchQuery.Disabled = true;
            StateHasChanged();
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