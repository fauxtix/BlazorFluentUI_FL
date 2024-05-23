using AutoMapper;
using EdamanFluentApi.Data.Enums;
using EdamanFluentApi.Models.Youtube.Dtos;
using EdamanFluentApi.Models.Youtube.Entities;
using EdamanFluentApi.Repositories.Interfaces;
using EdamanFluentApi.Services.Interfaces.Youtube;

namespace EdamanFluentApi.Services.Implementations.Youtube
{
    public class CategoriasService : ICategoriasService
    {
        private readonly ICategoriasRepository _mediaCategoriesRepository;
        private IMapper _mapper;
        public CategoriasService(ICategoriasRepository mediaCategoriesRepository, IMapper mapper)
        {
            _mediaCategoriesRepository = mediaCategoriesRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryVM>> AllAsync()
        {
            var entities = await _mediaCategoriesRepository.GetAllAsync();
            var mappedEntities = _mapper.Map<IEnumerable<CategoryVM>>(entities);
            return mappedEntities;
        }

        public async Task<bool> CategoriaComRegistos(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CreateCategory(CategoryVM categoria)
        {
            var entity = _mapper.Map<Categoria>(categoria);

            await _mediaCategoriesRepository.AddAsync(entity);
            return true;
        }

        public async Task<bool> UpdateCategory(int id, CategoryVM categoria)
        {
            var categoryToUpdate = _mapper.Map<Categoria>(categoria);
            await _mediaCategoriesRepository.UpdateAsync(categoryToUpdate);
            return true;
        }

        public async Task<bool> DeleteCategory(int id)
        {
            await _mediaCategoriesRepository.DeleteAsync(id);
            return true;
        }

        public async Task<IEnumerable<CategoryVM>> GetAllAsync(AppDefinitions.CategoryType category)
        {
            var entities = await _mediaCategoriesRepository.GetAllAsync();
            var mappedEntities = _mapper.Map<IEnumerable<CategoryVM>>(entities);
            return mappedEntities;
        }

        public async Task<CategoryVM> GetCategoriesById(int id)
        {
            var entity = await _mediaCategoriesRepository.GetByIdAsync(id);
            var mappedEntity = _mapper.Map<CategoryVM>(entity);
            return mappedEntity;
        }

        public async Task<IEnumerable<CategoryVM>> GetCategoriesWithMediaEntries()
        {
            var entries = await _mediaCategoriesRepository.GetCategoriesWithMediaEntries();
            var mappedEntries = _mapper.Map<IEnumerable<CategoryVM>>(entries);
            return mappedEntries;
        }

        public async Task<int> GetIdCategoria(string description)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CategoryVM>> Listar(int tipo)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CategoryVM>> Listar_Categoria(bool CalledFromPubs)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CategoryVM>> Listar_Categoria_List(string sDescricao, bool CalledFromPubs)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CategoryVM>> ListByType(AppDefinitions.Query_TipoMedia tipoMedia)
        {
            throw new NotImplementedException();
        }

        public List<MediaVM> MediaCatalogados(int CodCategoria)
        {
            throw new NotImplementedException();
        }

        public string RegistoComErros(CategoryVM categoria)
        {
            throw new NotImplementedException();
        }

    }
}
