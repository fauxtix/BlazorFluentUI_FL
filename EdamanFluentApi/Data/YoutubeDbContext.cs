using EdamanFluentApi.Models.Youtube.Dtos;
using EdamanFluentApi.Models.Youtube.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EdamanFluentApi.Data
{
    public class YoutubeDbContext : DbContext
    {
        IConfiguration _configuration;
        public YoutubeDbContext(DbContextOptions<YoutubeDbContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_configuration.GetConnectionString("YoutubeDB"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Media>()
                .HasOne(m => m.Categoria)
                .WithMany(c => c.MediaFiles)
                .HasForeignKey(m => m.IdGenero);

            modelBuilder.Entity<Media>()
                .HasOne(m => m.Formato_Media)
                .WithMany(f => f.MediaFiles)
                .HasForeignKey(m => m.IdFormato_Media);
        }


        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Formato_Media> Media_Formats { get; set; }
        public DbSet<ImageCategoryLocations> ImageCategoryLocations { get; set; }
        public DbSet<Media> MediaFiles { get; set; }
        public DbSet<TipoCategoria> CategoryTypes { get; set; }
        public DbSet<VideoCategoryLocations> VideoCategoryLocations { get; set; }
        public DbSet<YouTubeVideoDetails> VideoDetails { get; set; }
    }
}
