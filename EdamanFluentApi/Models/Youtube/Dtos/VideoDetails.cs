using System.ComponentModel.DataAnnotations;

namespace EdamanFluentApi.Models.Youtube.Dtos
{
    public class YouTubeVideoDetails
    {
        [Key]
        public string VideoId { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string ChannelTitle { get; set; }
        public string Duration { get; set; }
        public DateTime? PublicationDate { get; set; }
        public string Thumbnail { get; set; }
    }
}
