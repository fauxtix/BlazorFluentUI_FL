using EdamanFluentApi.Models.Youtube.Dtos;

public interface IYoutubeService
{
    Task AddMediaAsync(MediaVM media);
    Task DeleteMediaAsync(int id);
    Task<IEnumerable<MediaVM>> GetMediaAsync();
    Task<MediaVM> GetMediaFileByIdAsync(int id);

    Task<IEnumerable<MediaVM>> GetAllMediaAsync();
    Task<IEnumerable<VideoCategoryLocations>> GetAllMusicTitles();
    Task<MediaVM> GetMediaByIdAsync(int id);
    Task<MediaVM> GetMediaByTitle(string fileName);
    Task<int> GetMediaCategoryByDescription(string description);
    Task<string> GetMediaFormat(int mediaId);
    Task<int> GetMediaFormatByDescription(string formatDescription);
    Task<IEnumerable<FormatoMediaVM>> GetMediaFormats();
    Task<VideoCategoryLocations> GetMusicFile(int id);
    Task<IEnumerable<VideoCategoryLocations>> GetMusicMedia(int categoryId);
    Task<IEnumerable<VideoCategoryLocations>> GetVideoLocations(int categoryId);
    Task UpdateMediaAsync(MediaVM media);
    Task UpdateMediaFile_Cover(int id, string coverUrl);


}