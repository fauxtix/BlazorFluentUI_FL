using EdamanFluentApi.Model.FoodDatabase;
using EdamanFluentApi.Services.Interfaces.Edaman;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.FluentUI.AspNetCore.Components;
using Microsoft.JSInterop;

namespace EdamanFluentApi.Components.Pages.Edaman
{
    public partial class FoodDatabase
    {
        [Inject] IJSRuntime JSRuntime { get; set; }

        [Inject] public IFoodDatabaseService FoodService { get; set; }
        [Inject] public IAutoCompleteFoodDatabaseService AutoCompleteService { get; set; }

        [Inject] public ILogger<App> Logger { get; set; }

        protected FluentSearch searchQuery;
        private string searchValue = string.Empty;


        protected bool isLoading = false;

        protected List<Food> foodData = new();
        protected List<string> autocompleteData = new();

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

        protected override async Task OnInitializedAsync()
        {
            if (!string.IsNullOrEmpty(searchValue))
            {
                foodData = await GetFoodData(SearchValue);
            }
        }

        protected async Task<List<Food>> GetFoodData(string query)
        {
            try
            {
                isLoading = true;
                var output = await FoodService.RetrieveAllFoodItems(query);
                isLoading = false;
                return output;

            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message, ex);
                ShowToast(ex.Message);
                return [];
            }
        }

        protected async Task<List<string>> GetAutoCompleteData(string query)
        {
            try
            {
                isLoading = true;
                var output = await AutoCompleteService.RetrieveAutoCompleteItems(query);
                isLoading = false;
                return output;

            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message, ex);
                ShowToast(ex.Message);
                return [];
            }
        }


        protected async void OnSearch(MouseEventArgs args)
        {
            foodData.Clear();
            try
            {
                autocompleteData = await GetAutoCompleteData(SearchValue);
                foodData = await GetFoodData(SearchValue);

                if (foodData is null || foodData.Count == 0)
                {
                    ShowToast($"No records found for (Recipes) {SearchValue}");
                }
                if (autocompleteData is null || autocompleteData.Count == 0)
                {
                    ShowToast($"No records found for (AutoComplete)  {SearchValue}");
                }
                StateHasChanged();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message, ex);
                ShowToast(ex.Message);
            }
        }

        protected void ShowToast(string message)
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

        private void ScrollTop()
        {
            // JS interop call to perform scroll top
            JSRuntime.InvokeVoidAsync("scrollToTop");
        }

    }
}