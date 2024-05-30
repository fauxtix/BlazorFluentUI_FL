
using EdamanFluentApi.Models.Youtube.Entities;

namespace EdamanFluentApi.Repositories.Interfaces
{
    public interface ICategoriasRepository : IRepository<Categoria>
    {
        Task<IEnumerable<Categoria>> GetCategoriesWithMediaEntries();
    }
}
