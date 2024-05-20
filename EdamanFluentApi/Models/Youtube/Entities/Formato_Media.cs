namespace EdamanFluentApi.Models.Youtube.Entities
{
    public class Formato_Media
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public ICollection<Media> MediaFiles { get; set; }
    }
}
