
using EdamanFluentApi.Models.Youtube.Entities;

namespace EdamanFluentApi.Repositories.Interfaces
{
    public interface ICategoriasRepository : IRepository<Categoria>
    {
        Task<bool> CategoryInUse(int categoryId);
        Task<IEnumerable<Categoria>> GetCategoriesWithMediaEntries();
    }
}
