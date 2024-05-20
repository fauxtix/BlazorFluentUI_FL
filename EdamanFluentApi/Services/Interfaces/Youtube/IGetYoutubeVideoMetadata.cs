using EdamanFluentApi.Models.Youtube.Dtos;

namespace EdamanFluentApi.Services.Interfaces.Youtube
{
    public interface IGetYoutubeVideoMetadata
    {
        Task<YouTubeVideoDetails> GetAlbumArtistMetadata(string searchRequest_query);
        Task<YouTubeVideoDetails> GetSingleVideoMetadata(string searchRequest_query);
        Task<YouTubeVideoDetails> GetVideoMetadata(string searchRequest_Id);
        Task<YouTubeVideoDetails> SearchByArtistAndSong(string artistName, string songName);

    }
}
