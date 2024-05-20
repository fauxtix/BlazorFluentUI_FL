using EdamanFluentApi.Models.Youtube.Dtos;

namespace EdamanFluentApi.Services.Interfaces.Youtube
{
    public interface IFormatos_MediaService
    {
        Task<bool> CreateMediaFormat(FormatoMediaVM formatoPublicacaoVM);
        Task<bool> DeleteMediaFormat(int id);
        Task<IEnumerable<FormatoMediaVM>> GetAllAsync();
        Task<FormatoMediaVM> GetFormatosMediaById(int id);
        Task<bool> UpdateMediaFormat(int id, FormatoMediaVM formatoFormatDTO);
        Task<List<FormatoMediaVM>> Listar();
        Task<int> GetIdFormato(string description);
        string RegistoComErros(FormatoMediaVM formato);
        List<MediaVM> Media_CatalogadosByFormato(int CodFormato);
    }
}