using EdamanFluentApi.Models.Youtube.Dtos;
using Microsoft.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components;

namespace EdamanFluentApi.Components.Pages.Youtube;

public partial class YoutubeManager
{
    bool _clearItems = false;
    protected IQueryable<MediaVM> items { get; set; }

    public record MediaRecord
    {
        public MediaVM SelectedRecord { get; set; }
        public bool EditMode { get; set; }
    }


    protected MediaVM SelectedRecord = new();
    public MediaRecord MediaRecordToUse { get; set; } = new();

    PaginationState pagination = new PaginationState { ItemsPerPage = 10 };
    string nameFilter = string.Empty;
    bool spinnerVisible;

    private IDialogReference? _dialog;

    GridSort<MediaVM> rankSort = GridSort<MediaVM>
        .ByDescending(x => x.FileName);

    Func<MediaVM, string> rowClass = x => x.Id % 2 == 0 ? "highlighted-row" : null;
    Func<MediaVM, string> rowStyle = x => x.Id % 2 == 0 ? "background-color: var(--highlight-bg);" : null;

    protected override async Task OnInitializedAsync()
    {
        await GetMediaFiles();
    }

    private void HandleCountryFilter(ChangeEventArgs args)
    {
        if (args.Value is string value)
        {
            nameFilter = value;
        }
    }

    private void HandleClear()
    {
        if (string.IsNullOrWhiteSpace(nameFilter))
        {
            nameFilter = string.Empty;
        }
    }

    private async Task ToggleItemsAsync()
    {
        if (_clearItems)
        {
            items = null;
        }
        else
        {
            await GetMediaFiles();
        }
    }

    private async Task GetMediaFiles()
    {
        spinnerVisible = true;
        var result = await youtubeService.GetMediaAsync();
        items = result.AsQueryable();
        spinnerVisible = false;
    }

    public async Task EditMediaRecord(MediaVM mediaRecord)
    {

        MediaRecordToUse = new MediaRecord()
        {
            SelectedRecord = mediaRecord,
            EditMode = true
        };

        var dialogParameters = new DialogParameters
        {
            ShowTitle = true,
            Modal = true,
            Title = mediaRecord.Titulo,
            Alignment = HorizontalAlignment.Center,
            PrimaryAction = "Save",
            SecondaryAction = "Cancel",
            Width = "700px",
            Height = "auto",
        };

        _dialog = await DialogService.ShowDialogAsync<EditYoutube>(MediaRecordToUse, dialogParameters);
        DialogResult? result = await _dialog.Result;
        if (!result.Cancelled)
        {
            ShowToast("Record successfully updated", ToastIntent.Success);

            await GetMediaFiles();
        }

    }

    public async Task PlayMedia(MediaVM mediaRecord)
    {

        MediaRecordToUse = new MediaRecord()
        {
            SelectedRecord = mediaRecord,
            EditMode = true
        };

        var dialogParameters = new DialogParameters
        {
            ShowTitle = true,
            Modal = true,
            Title = mediaRecord.Titulo,
            Alignment = HorizontalAlignment.Center,
            PrimaryAction = "Close",
            Width = "780px",
            Height = "600px",
        };

        _dialog = await DialogService.ShowDialogAsync<Player>(MediaRecordToUse, dialogParameters);
        DialogResult? result = await _dialog.Result;
        if (!result.Cancelled)
        {
            await GetMediaFiles();
        }

    }
    public async Task NotifyAddingYoutubeRecord()
    {
        int iFormato = await youtubeService.GetMediaFormatByDescription("A partir de URL");
        int iGenero = await youtubeService.GetMediaCategoryByDescription("Tutorial - Vídeo - .Net");

        var mediaClassToUseInDialog = new MediaVM()
        {
            Id = 0,
            DataMov = DateTime.Now,
            TipoMedia = 2,
            Visualizado = true, // we'll assume that we've already listen/read the title about to be created
            IdFormato_Media = iFormato,
            IdGenero = iGenero,
            FileUrl = ""
        };

        MediaRecordToUse = new MediaRecord()
        {
            SelectedRecord = mediaClassToUseInDialog,
            EditMode = false
        };



        var dialogParameters = new DialogParameters
        {
            ShowTitle = true,
            Modal = true,
            Title = "Create Youtube record",
            Alignment = HorizontalAlignment.Center,
            PrimaryAction = "Save",
            SecondaryAction = "Cancel",
            Width = "700px",
            Height = "auto",

        };

        _dialog = await DialogService.ShowDialogAsync<EditYoutube>(MediaRecordToUse, dialogParameters);
        DialogResult? result = await _dialog.Result;
        if (!result.Cancelled)
        {
            ShowToast("Record successfully created", ToastIntent.Success);
            await GetMediaFiles();
        }
    }

    public async Task DeleteMedia(int  mediaId, string mediaTitle)
    {
        var title = string.IsNullOrEmpty(mediaTitle) ? "Record" : mediaTitle;
        var dialog = await DialogService.ShowConfirmationAsync($"Confirm operation?", "Yes", "No", $"Delete '{title}'");
        var result = await dialog.Result;
        var canceled = result.Cancelled;
        if (!canceled)
        {
            var mediaFile = await youtubeService.GetMediaByIdAsync(mediaId);
            if (mediaFile is not null)
            {
                await youtubeService.DeleteMediaAsync(mediaId);
                ShowToast("Record successfully deleted", ToastIntent.Success);

                await GetMediaFiles();
            }
        }
    }

    private void ShowToast(string msg, ToastIntent intent)
    {

        var message = msg;
        ToastService.ShowToast(intent, message, 1500);
    }

}