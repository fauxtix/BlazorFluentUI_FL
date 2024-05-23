using AutoMapper;
using EdamanFluentApi.Models.Youtube.Dtos;
using EdamanFluentApi.Models.Youtube.Entities;
using EdamanFluentApi.Repositories.Interfaces;
using EdamanFluentApi.Services.Interfaces.Youtube;
using Google.Apis.YouTube.v3.Data;
using System.Reflection.Metadata.Ecma335;

namespace EdamanFluentApi.Services.Implementations.Youtube
{
    public class FormatosMediaService : IFormatos_MediaService
    {
        private readonly IFormatos_MediaRepository _mediaFormatsRepository;
        private IMapper _mapper;

        public FormatosMediaService(IFormatos_MediaRepository mediaFormatsRepository, IMapper mapper)
        {
            _mediaFormatsRepository = mediaFormatsRepository;
            _mapper = mapper;
        }
        public async Task<bool> CreateMediaFormat(FormatoMediaVM formatoPublicacaoVM)
        {
            var entity = _mapper.Map<Formato_Media>(formatoPublicacaoVM);

            await _mediaFormatsRepository.AddAsync(entity);
            return true;
        }

        public async Task<bool> DeleteMediaFormat(int id)
        {
            await _mediaFormatsRepository.DeleteAsync(id);
            return true;
        }

        public async Task<IEnumerable<FormatoMediaVM>> GetAllAsync()
        {
            var entityFormats = await _mediaFormatsRepository.GetAllAsync();
            var mappedList = _mapper.Map<IEnumerable<FormatoMediaVM>>(entityFormats);
            return mappedList;
        }

        public async Task<FormatoMediaVM> GetFormatosMediaById(int id)
        {
            var entity = await _mediaFormatsRepository.GetByIdAsync(id);
            var mappedEntity = _mapper.Map<FormatoMediaVM>(entity);
            return mappedEntity;
        }

        public async Task<int> GetIdFormato(string description)
        {
            throw new NotImplementedException();
        }

        public async Task<List<FormatoMediaVM>> Listar()
        {
            throw new NotImplementedException();
        }

        public List<MediaVM> Media_CatalogadosByFormato(int CodFormato)
        {
            throw new NotImplementedException();
        }

        public string RegistoComErros(FormatoMediaVM formato)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateMediaFormat(int id, FormatoMediaVM formatoDTO)
        {
            var mappedEntity = _mapper.Map<Formato_Media>(formatoDTO);
            await _mediaFormatsRepository.UpdateAsync(mappedEntity);
            return true;
        }
    }
}
