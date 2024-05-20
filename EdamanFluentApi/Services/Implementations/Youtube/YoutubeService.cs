using AutoMapper;
using EdamanFluentApi.Models.Youtube.Dtos;
using EdamanFluentApi.Models.Youtube.Entities;
using EdamanFluentApi.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

public class YoutubeService : IYoutubeService
{
    private readonly IYoutubeRepository _youtubeRepository;
    private IMapper _mapper;


    public YoutubeService(IYoutubeRepository youtubeRepository, IMapper mapper)
    {
        _youtubeRepository = youtubeRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<MediaVM>> GetAllMediaAsync()
    {
        var mediaFiles = await _youtubeRepository.GetAllAsync();
        var result = _mapper.Map<IEnumerable<MediaVM>>(mediaFiles);
        return result;
    }

    public async Task<MediaVM> GetMediaByIdAsync(int id)
    {
        var mediaFile = await _youtubeRepository.GetByIdAsync(id);
        var result = _mapper.Map<MediaVM>(mediaFile);
        return result;
    }

    public async Task AddMediaAsync(MediaVM mediaFile)
    {
        var entity= _mapper.Map<Media>(mediaFile);

        await _youtubeRepository.AddAsync(entity);
    }

    public async Task UpdateMediaAsync(MediaVM mediaFile)
    {
        var entity = _mapper.Map<Media>(mediaFile);

        await _youtubeRepository.UpdateAsync(entity);
    }

    public async Task DeleteMediaAsync(int id)
    {
        await _youtubeRepository.DeleteAsync(id);
    }

    public async Task<MediaVM> GetMediaByTitle(string fileName)
    {
        var media = await _youtubeRepository.GetMediaByTitle(fileName);
        if (media == null)
        {
            return null;
        }

        return new MediaVM
        {
            AnoEdicao = media.AnoEdicao,
            Autor = media.Autor,
        };
    }

    public async Task<IEnumerable<FormatoMediaVM>> GetMediaFormats()
    {
        var mediaformats = await _youtubeRepository.GetMediaFormats();
        var result = _mapper.Map<IEnumerable<FormatoMediaVM>>(mediaformats);

        return result;
    }

    public async Task<string> GetMediaFormat(int mediaId)
    {
        return await _youtubeRepository.GetMediaFormat(mediaId);
    }

    public async Task<int> GetMediaFormatByDescription(string formatDescription)
    {
        return await _youtubeRepository.GetMediaFormatByDescription(formatDescription);
    }

    public async Task<int> GetMediaCategoryByDescription(string description)
    {
        return await _youtubeRepository.GetMediaCategoryByDescription(description);
    }

    public async Task<IEnumerable<VideoCategoryLocations>> GetVideoLocations(int categoryId)
    {
        return await _youtubeRepository.GetVideoLocations(categoryId);
    }

    public async Task<IEnumerable<VideoCategoryLocations>> GetMusicMedia(int categoryId)
    {
        return await _youtubeRepository.GetMusicMedia(categoryId);
    }

    public async Task<IEnumerable<VideoCategoryLocations>> GetAllMusicTitles()
    {
        return await _youtubeRepository.GetAllMusicTitles();
    }

    public async Task UpdateMediaFile_Cover(int id, string coverUrl)
    {
        await _youtubeRepository.UpdateMediaFile_Cover(id, coverUrl);
    }

    public async Task<VideoCategoryLocations> GetMusicFile(int id)
    {
        return await _youtubeRepository.GetMusicFile(id);
    }

    public async Task<IEnumerable<MediaVM>> GetMediaAsync()
    {
        return await _youtubeRepository.GetMediaAsync();
    }
}
