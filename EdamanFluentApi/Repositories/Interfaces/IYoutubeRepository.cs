using EdamanFluentApi.Models.Youtube.Dtos;
using EdamanFluentApi.Models.Youtube.Entities;

namespace EdamanFluentApi.Repositories.Interfaces;

public interface IYoutubeRepository : IRepository<Media>
{
    Task<Media> GetMediaByTitle(string fileName);
    Task<IEnumerable<Formato_Media>> GetMediaFormats();
    Task<string> GetMediaFormat(int mediaId);
    Task<int> GetMediaFormatByDescription(string formatDescription);
    Task<int> GetMediaCategoryByDescription(string description);
    Task<IEnumerable<VideoCategoryLocations>> GetVideoLocations(int categoryId);
    Task<IEnumerable<VideoCategoryLocations>> GetMusicMedia(int categoryId);
    Task<IEnumerable<VideoCategoryLocations>> GetAllMusicTitles();
    Task UpdateMediaFile_Cover(int Id, string coverUrl);
    Task<VideoCategoryLocations> GetMusicFile(int Id);
    Task<IEnumerable<MediaVM>> GetMediaAsync();
}
