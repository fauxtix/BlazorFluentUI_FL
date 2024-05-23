using EdamanFluentApi.Models.Youtube.Dtos;
using EdamanFluentApi.Models.Youtube.Entities;

namespace EdamanFluentApi.Repositories.Interfaces
{
    public interface IFormatos_MediaRepository : IRepository<Formato_Media>
    {
        Task<string> GetNomeFormato(int idFormato);
        Task<List<Formato_Media>> Listar_Formato(string sDescricao);
        Task<List<MediaVM>> Media_Catalogados();
        Task<List<MediaVM>> Media_CatalogadosByFormato(int CodFormato);
    }
}
