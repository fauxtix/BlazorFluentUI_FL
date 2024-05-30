using EdamanFluentApi.Data;
using EdamanFluentApi.Models.Youtube.Dtos;
using EdamanFluentApi.Models.Youtube.Entities;
using EdamanFluentApi.Repositories.Implementations;
using EdamanFluentApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

public class YoutubeRepository : Repository<Media>, IYoutubeRepository, IDisposable
{
    protected  readonly YoutubeDbContext _context;
    public YoutubeRepository(YoutubeDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<MediaVM>> GetMediaAsync()
    {
        var mediaQuery = _context.MediaFiles
            .Include(m => m.Categoria)
            .Include(m => m.Formato_Media)
            .AsNoTracking()
            .OrderByDescending(m => m.Id)
            .Select(m => new MediaVM
            {
                Id = m.Id,
                FileName = m.FileName,
                DataMov = m.DataMov,
                FilePath = m.FilePath,
                FileUrl = m.FileUrl,
                TipoMedia = m.TipoMedia,
                Visualizado = m.Visualizado,
                Rating = m.Rating,
                Notas = m.Notas,
                IdGenero = m.IdGenero,
                Autor = m.Autor,
                AnoEdicao = m.AnoEdicao,
                GuardaEmdisco = m.GuardaEmdisco,
                IdFormato_Media = m.IdFormato_Media,
                Genero = m.Categoria.Descricao,
                FormatoMedia = m.Formato_Media.Descricao,
                Tempo = GetAttributeValue(m.Notas, "Tempo"),
                Tamanho = GetAttributeValue(m.Notas, "Tamanho"),
                CoverFile = m.CoverFile
            });

        var result = (await mediaQuery.ToListAsync());
        return result;
    }

    public async Task<MediaVM> GetMediaFileByIdAsync(int id)
    {
        var mediaQuery = _context.MediaFiles
            .Include(m => m.Categoria)
            .Include(m => m.Formato_Media)
            .AsNoTracking()
            .OrderByDescending(m => m.FileName)
            .Select(m => new MediaVM
            {
                Id = m.Id,
                FileName = m.FileName,
                DataMov = m.DataMov,
                FilePath = m.FilePath,
                FileUrl = m.FileUrl,
                TipoMedia = m.TipoMedia,
                Visualizado = m.Visualizado,
                Rating = m.Rating,
                Notas = m.Notas,
                IdGenero = m.IdGenero,
                Autor = m.Autor,
                AnoEdicao = m.AnoEdicao,
                GuardaEmdisco = m.GuardaEmdisco,
                IdFormato_Media = m.IdFormato_Media,
                Genero = m.Categoria.Descricao,
                FormatoMedia = m.Formato_Media.Descricao,
                Tempo = GetAttributeValue(m.Notas, "Tempo"),
                Tamanho = GetAttributeValue(m.Notas, "Tamanho"),
                CoverFile = m.CoverFile
            });

        var result = await mediaQuery.FirstOrDefaultAsync(m => m.Id == id);
        return result;

    }


    public async Task<Media> GetMediaByTitle(string filePath)
    {
        return await _context.MediaFiles
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.FilePath == filePath);
    }

    public async Task<IEnumerable<Formato_Media>> GetMediaFormats()
    {
        return await _context.Media_Formats
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<string> GetMediaFormat(int mediaId)
    {
        var media = await _context.MediaFiles.FindAsync(mediaId);
        return media?.FileName;
    }

    public async Task<int> GetMediaFormatByDescription(string formatDescription)
    {
        var format = await _context.Media_Formats
            .AsNoTracking()
            .FirstOrDefaultAsync(f => f.Descricao == formatDescription);
        return format?.Id ?? 0;
    }

    public async Task<int> GetMediaCategoryByDescription(string description)
    {
        var category = await _context.CategoryTypes
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Descricao == description);
        return category?.Id ?? 0;
    }

    public async Task<IEnumerable<VideoCategoryLocations>> GetVideoLocations(int categoryId)
    {
        return await _context.VideoCategoryLocations
            .AsNoTracking()
            .Where(v => v.Id == categoryId).ToListAsync();
    }

    public async Task<IEnumerable<VideoCategoryLocations>> GetMusicMedia(int categoryId)
    {
        return await _context.VideoCategoryLocations
            .AsNoTracking()
            .Where(v => v.Id == categoryId && v.Categoria == "Music")
            .ToListAsync();
    }

    public async Task<IEnumerable<VideoCategoryLocations>> GetAllMusicTitles()
    {
        return await _context.VideoCategoryLocations.Where(v => v.Categoria == "Music").ToListAsync();
    }

    public async Task UpdateMediaFile_Cover(int id, string coverUrl)
    {
        var media = await _context.MediaFiles.FindAsync(id);
        if (media != null)
        {
            media.CoverFile = coverUrl;
            await _context.SaveChangesAsync();
        }
    }

    public async Task<VideoCategoryLocations> GetMusicFile(int id)
    {
        return await _context.VideoCategoryLocations.FindAsync(id);
    }

    private static string GetAttributeValue(string notas, string attribute)
    {
        if(string.IsNullOrEmpty(notas))
        {
            if (attribute.ToLower() == "tempo")
                return "00:00:00";
            else // tamanho
            {
                return "0 Kb";
            }
        }

        int attributeIndex = notas.IndexOf(attribute);
        if (attributeIndex != -1)
        {
            int startIndex = attributeIndex + attribute.Length + 3; // Move past attribute name and two spaces
            int endIndex = notas.IndexOf(" ", startIndex);
            if (endIndex != -1)
            {
                string value = notas.Substring(startIndex, endIndex - startIndex);
                return value.Replace(',', '.');
            }
        }
        return "0.00";
    }

    private bool _disposed = false;
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        _disposed = true;
    }
}
