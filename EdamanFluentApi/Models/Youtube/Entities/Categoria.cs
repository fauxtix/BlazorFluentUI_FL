namespace EdamanFluentApi.Models.Youtube.Entities
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public ICollection<Media> MediaFiles { get; set; }
    }
}
