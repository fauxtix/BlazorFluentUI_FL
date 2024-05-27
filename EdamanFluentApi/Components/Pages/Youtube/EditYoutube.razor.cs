using EdamanFluentApi.Models.Youtube.Dtos;
using EdamanFluentApi.Services.Interfaces.Youtube;
using Microsoft.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components;
using System.Diagnostics.Metrics;

namespace EdamanFluentApi.Components.Pages.Youtube;

public partial class EditYoutube
{
    [CascadingParameter] public FluentDialog Dialog { get; set; } = default!;
    [Parameter] public YoutubeManager.MediaRecord Content { get; set; } = default!;

    [Inject]
    public IMessageService MessageService { get; set; }
    [Inject] public IFormatos_MediaService FormatosService { get; set; }
    [Inject] public NavigationManager NavigationManager { get; set; }

    [Inject] public IYoutubeService YoutubeService { get; set; }
    [Inject] public ICategoriasService CategoriasService { get; set; }
    [Inject] public IGetYoutubeVideoMetadata YoutubeMetadataService { get; set; }

    private IEnumerable<FormatoMediaVM> formatList;
    private IEnumerable<CategoryVM> categoryList;

    private bool isLoadingData = false;
    private bool Loading;
    protected DateTime? transDate;

    private bool showAlertMessage = false;
    private bool DisableSaveButton = true;
    private string alertMessage = "";
    private bool hideLowerDiv = true;

    string categoryAsString = string.Empty;
    string mediaFormatAsString = string.Empty;
    protected override async Task OnInitializedAsync()
    {
        await GetLookupData();
    }

    protected override void OnParametersSet()
    {
        var CurrentSelectedRecord = Content.SelectedRecord;
        var currentSelectedMediaId = Content.SelectedRecord.Id;
        transDate = currentSelectedMediaId == 0 ? DateTime.Now.Date : CurrentSelectedRecord.DataMov;
        categoryAsString = currentSelectedMediaId == 0 ? "28" : CurrentSelectedRecord.IdGenero.ToString(); // Other
        mediaFormatAsString = currentSelectedMediaId == 0 ? "6" : CurrentSelectedRecord.IdFormato_Media.ToString(); // from Url
        if(currentSelectedMediaId > 0)
        {
            hideLowerDiv = false;
            DisableSaveButton = false;
        }
    }

    private async Task ValidHandlerAsync()
    {
        Loading = true;

        // Simulate asynchronous loading
        await Task.Delay(1000);

        Loading = false;
    }
    private async Task GetLookupData()
    {
        formatList = (await FormatosService
            .GetAllAsync())
            .OrderBy(c=>c.Descricao)
            .ToList();
        categoryList = (await CategoriasService
            .AllAsync())
            .OrderBy(c => c.Descricao)
            .ToList();
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

        await InformUserAndRefreshGrid();
    }


    private async Task InsertRecord()
    {
        var data = Content.SelectedRecord;

        data.IdGenero = int.Parse(categoryAsString);
        data.IdFormato_Media = int.Parse(mediaFormatAsString);

        await YoutubeService.AddMediaAsync(data);

        StateHasChanged();
        await Task.Delay(100);
        await Dialog.CloseAsync(Content);
    }

    private async Task UpdateRecord()
    {
        var data = Content.SelectedRecord;

        data.IdGenero = int.Parse(categoryAsString);
        data.IdFormato_Media = int.Parse(mediaFormatAsString);


        await YoutubeService.UpdateMediaAsync(data);

        await Task.Delay(100);
        await Dialog.CloseAsync(Content);

        // ToastContent = InsertUpdateOk ? localizerApp["SuccessUpdate"] : localizerApp["FalhaGravacaoRegisto"];
        // ToastTitle = localizerApp["editionMsg"];
        // ToastTimeOut = 3000;
    }

    private async Task InformUserAndRefreshGrid()
    {
        // YouTubePlayerDialogVisibility = false;
        // EditMediaDialogVisibility = false;
        // YouTubeDialogVisibility = false;
        // StateHasChanged();

        // await Task.Delay(200);
        // await ToastObj.ShowAsync();

        // await SpinnerObj.ShowAsync();

        await GetLookupData();
        // await SpinnerObj.HideAsync();
    }

    private async Task GetMetadata()
    {
        showAlertMessage = false;
        alertMessage = "";
        if (!string.IsNullOrEmpty(Content.SelectedRecord.FileUrl))
        {
            int indexPos = Content.SelectedRecord.FileUrl.IndexOf("v=") + 2;
            string videoId = Content.SelectedRecord.FileUrl.Substring(indexPos);
            var videoMetadata = await YoutubeMetadataService.GetVideoMetadata(videoId);

            if (videoMetadata is not null)
            {
                if (Content.SelectedRecord.Id == 0) // Create new entry, try to fill the form Fields
                {
                    var categoriasMedia = (await CategoriasService.GetCategoriesWithMediaEntries()).ToList();
                    var categoriaMedia = categoriasMedia.SingleOrDefault(f => f.Descricao != null && f.Descricao.ToLower().Contains("other"));
                    int? idCategoriaMedia = categoriaMedia?.Id;

                    var formatosMedia = (await FormatosService.GetAllAsync()).ToList();
                    var formatoMedia = formatosMedia.SingleOrDefault(f => f.Descricao.ToLower().Contains("url"));
                    int? idFormatoMedia = formatoMedia?.Id;

                    Content.SelectedRecord.AnoEdicao = videoMetadata.PublicationDate.Value.Year.ToString();
                    Content.SelectedRecord.Autor = videoMetadata.ChannelTitle;
                    Content.SelectedRecord.FileName = videoMetadata.Title;
                    Content.SelectedRecord.Tempo = videoMetadata.Duration;
                    Content.SelectedRecord.IdGenero = idCategoriaMedia.HasValue ? idCategoriaMedia.Value : Content.SelectedRecord.IdGenero;
                    Content.SelectedRecord.IdFormato_Media = idFormatoMedia.HasValue ? idFormatoMedia.Value : Content.SelectedRecord.IdFormato_Media;
                    Content.SelectedRecord.Notas = videoMetadata.Description;
                    transDate = videoMetadata.PublicationDate.Value;
                    Content.SelectedRecord.CoverFile = videoMetadata.Thumbnail ?? "";

                    hideLowerDiv = false;
                    DisableSaveButton = false;
                    StateHasChanged();
                }
                else
                {
                    Content.SelectedRecord.Tempo = videoMetadata.Duration;
                }
            }
            else
            {
                alertMessage = "No data returned";
                showAlertMessage = true;
            }
        }
        else
        {
        }
    }

    private async Task CloseAsync()
    {
        await Dialog.CloseAsync(Content);
    }

    private async Task CancelAsync()
    {
        await Dialog.CancelAsync();
    }

}