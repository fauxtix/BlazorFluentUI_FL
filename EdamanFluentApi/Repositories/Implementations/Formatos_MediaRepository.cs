using EdamanFluentApi.Data;
using EdamanFluentApi.Models.Youtube.Dtos;
using EdamanFluentApi.Models.Youtube.Entities;
using EdamanFluentApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Text;

namespace EdamanFluentApi.Repositories.Implementations
{
    public class Formatos_MediaRepository : Repository<Formato_Media>, IFormatos_MediaRepository
    {
        protected readonly YoutubeDbContext _context;
        public Formatos_MediaRepository(YoutubeDbContext context) : base(context)
        {
            _context = context;
        }


        public async Task<string> GetNomeFormato(int IdFormato_Media)
        {
            var res = await _context.Media_Formats
                .AsNoTracking()
                .OrderBy(f=>f.Descricao)
                .SingleOrDefaultAsync(f => f.Id == IdFormato_Media);
            return res.Descricao;
        }

        public async Task<List<Formato_Media>> Listar_Formato(string Descricao)
        {
            var formatos = await _context.Media_Formats
                .AsNoTracking()
                .Where(f => f.Descricao == Descricao).ToListAsync();
            return formatos;
        }

        public async Task<List<MediaVM>> Media_CatalogadosByFormato(int IdFormato_Media)
        {
            var result = await _context.MediaFiles
                   .Where(m => m.IdFormato_Media == IdFormato_Media)
                   .Include(m => m.Categoria)
                   .AsNoTracking()
                   .Select(m => new MediaVM
                   {
                       FileName = m.FileName,
                       Autor = m.Autor,
                       Genero = m.Categoria.Descricao
                   })
                   .OrderBy(m => m.FileName)
                   .ToListAsync();

            return result;
        }
        public async Task<List<MediaVM>> Media_Catalogados()
        {
            var result = await _context.MediaFiles
                  .Include(m => m.Categoria)
                  .AsNoTracking()
                  .Select(m => new MediaVM
                  {
                      FileName = m.FileName,
                      Autor = m.Autor,
                      Genero = m.Categoria.Descricao
                  })
                  .OrderBy(m => m.FileName)
                  .ToListAsync();

            return result;
        }
    }
}
