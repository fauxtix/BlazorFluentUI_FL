using EdamanFluentApi.Models.Youtube.Dtos;
using EdamanFluentApi.Services.Interfaces.Youtube;
using Microsoft.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components;

namespace EdamanFluentApi.Components.Pages.Youtube;

public partial class EditCategory
{
    [CascadingParameter] public FluentDialog Dialog { get; set; } = default!;
    [Parameter] public CategoriesManager.CategoryRecord Content { get; set; } = default!;

    [Inject]
    public IMessageService MessageService { get; set; }

    [Inject] public NavigationManager NavigationManager { get; set; }

    [Inject] public ICategoriasService CategoriasService { get; set; }

    public CategoryVM CurrentSelectedRecord { get; set; }
    public int CurrentSelectedCategoryId { get; set; }
    private ToastIntent ToastIntent { get; set; }
    private string ToastTitle { get; set; }

    private bool isLoadingData = false;
    private bool Loading;
    protected DateTime? transDate;

    private bool showAlertMessage = false;
    private bool DisableSaveButton = true;
    private string alertMessage = "";
    private bool hideLowerDiv = true;

    string categoryAsString = string.Empty;
    string mediaFormatAsString = string.Empty;

    protected override void OnParametersSet()
    {

        CurrentSelectedRecord = Content.SelectedRecord;
        CurrentSelectedCategoryId = CurrentSelectedRecord.Id;
    }

    private async Task ValidHandlerAsync()
    {
        Loading = true;

        // Simulate asynchronous loading
        await Task.Delay(1000);

        Loading = false;
    }

    public async Task AddOrSaveRecord()
    {
        if (Content.EditMode)
        {
            await UpdateRecord();
        }
        else
        {
            await InsertRecord();
        }

        // await InformUserAndRefreshGrid();
    }


    private async Task InsertRecord()
    {        
        await CategoriasService.CreateCategory(CurrentSelectedRecord);

        ToastTitle = "New record";
        alertMessage = "Record created successully";
        ToastIntent = ToastIntent.Info;
        showAlertMessage = true;

        StateHasChanged();
        await CloseAsync();
    }

    private async Task UpdateRecord()
    {
        try
        {
            await CategoriasService.UpdateCategory(CurrentSelectedRecord.Id, CurrentSelectedRecord);
        }
        catch (Exception ex)
        {
            var msg = ex.Message;
            throw;
        }

        ToastTitle = "Edit record";
        alertMessage = "Record updated successully";
        ToastIntent = ToastIntent.Info;
        showAlertMessage = true;
        StateHasChanged();
        await CloseAsync();
    }


    private async Task CloseAsync()
    {
        await Task.Delay(200);
        await Dialog.CloseAsync();
    }

    private async Task CancelAsync()
    {
        await Task.Delay(200);
        await Dialog.CancelAsync();
    }
}