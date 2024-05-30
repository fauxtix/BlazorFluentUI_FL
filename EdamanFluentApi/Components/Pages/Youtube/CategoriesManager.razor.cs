using EdamanFluentApi.Models.Youtube.Dtos;
using EdamanFluentApi.Services.Interfaces.Youtube;
using Microsoft.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components;

namespace EdamanFluentApi.Components.Pages.Youtube
{
    public partial class CategoriesManager
    {
        [Inject] ICategoriasService CategoriesService { get; set; }
        [Inject] IDialogService DialogService { get; set; }


        private IDialogReference? _dialog;

        private IQueryable<CategoryVM> categoryList;

        public record CategoryRecord
        {
            public CategoryVM SelectedRecord { get; set; }
            public bool EditMode { get; set; }
        }

        public CategoryRecord CategoryRecordToUse { get; set; } = new();

        private bool spinnerVisible;

        PaginationState pagination = new PaginationState { ItemsPerPage = 10 };
        protected override async Task OnInitializedAsync()
        {
            await GetCategories();
        }

        private async Task NotifyAddingCategoryRecord()
        {
            var categoryClassToUseInDialog = new CategoryVM()
            {
                Id = 0,
                Descricao = ""
            };

            CategoryRecordToUse = new CategoryRecord()
            {
                SelectedRecord = categoryClassToUseInDialog,
                EditMode = false
            };

            var dialogParameters = new DialogParameters
            {
                ShowTitle = true,
                Modal = true,
                Title = "Create category record",
                Alignment = HorizontalAlignment.Center,
                PrimaryAction = "Save",
                SecondaryAction = "Cancel",
                Width = "500px",
                Height = "auto",

            };

            _dialog = await DialogService.ShowDialogAsync<EditCategory>(CategoryRecordToUse, dialogParameters);
            DialogResult? result = await _dialog.Result;
            if (result.Cancelled)
            {
                ShowToast("Insert cancelled", ToastIntent.Success);
            }
            else
            {
                await GetCategories();
            }
        }

        protected async Task EditCategory(CategoryVM category)
        {
            CategoryRecordToUse = new CategoryRecord()
            {
                SelectedRecord = category,
                EditMode = true
            };

            var dialogParameters = new DialogParameters
            {
                ShowTitle = true,
                Modal = true,
                Title = "Update Category ",
                Alignment = HorizontalAlignment.Center,
                PrimaryAction = "Save",
                SecondaryAction = "Cancel",
            };

            _dialog = await DialogService.ShowDialogAsync<EditCategory>(CategoryRecordToUse, dialogParameters);
            DialogResult? result = await _dialog.Result;
            if (result.Cancelled)
            {
                ShowToast("Update  cancelled", ToastIntent.Success);
            }
            else
            {
                await GetCategories();
            }

        }

        protected async Task DeleteCategory(int categoryId, string categoryDescription)
        {
            var title = string.IsNullOrEmpty(categoryDescription) ? "Record" : categoryDescription;
            var dialog = await DialogService.ShowConfirmationAsync($"Confirm operation?", "Yes", "No", $"Delete '{title}'");
            var result = await dialog.Result;
            var canceled = result.Cancelled;
            if (!canceled)
            {
                var mediaFile = await CategoriesService.GetCategoriesById(categoryId);
                if (mediaFile is not null)
                {
                    await CategoriesService.DeleteCategory(categoryId);
                    ShowToast("Record deleted successfully", ToastIntent.Warning);
                    await GetCategories();
                }
            }

        }


        protected async Task GetCategories()
        {
            spinnerVisible = true;

            var data = (await CategoriesService
            .AllAsync())
            .OrderBy(c => c.Descricao)
            .ToList();

            categoryList = data.AsQueryable();
            spinnerVisible = false;

        }


        private void ShowToast(string msg, ToastIntent intent)
        {

            var message = msg;
            ToastService.ShowToast(intent, message, 1500);
        }

    }
}