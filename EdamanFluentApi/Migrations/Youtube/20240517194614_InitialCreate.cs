using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EdamanFluentApi.Migrations.Youtube
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true),
                    TipoCategoria = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImageCategoryLocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titulo = table.Column<string>(type: "TEXT", nullable: true),
                    IdCategoria = table.Column<int>(type: "INTEGER", nullable: false),
                    Categoria = table.Column<string>(type: "TEXT", nullable: true),
                    AnoEdicao = table.Column<string>(type: "TEXT", nullable: true),
                    ImagemCapa = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageCategoryLocations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Media_Formats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Media_Formats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MediaFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FileName = table.Column<string>(type: "TEXT", nullable: true),
                    DataMov = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FilePath = table.Column<string>(type: "TEXT", nullable: true),
                    FileUrl = table.Column<string>(type: "TEXT", nullable: true),
                    TipoMedia = table.Column<byte>(type: "INTEGER", nullable: false),
                    Visualizado = table.Column<bool>(type: "INTEGER", nullable: false),
                    Rating = table.Column<int>(type: "INTEGER", nullable: false),
                    Notas = table.Column<string>(type: "TEXT", nullable: true),
                    IdGenero = table.Column<int>(type: "INTEGER", nullable: false),
                    Autor = table.Column<string>(type: "TEXT", nullable: true),
                    AnoEdicao = table.Column<string>(type: "TEXT", nullable: true),
                    Tempo = table.Column<string>(type: "TEXT", nullable: true),
                    GuardaEmdisco = table.Column<int>(type: "INTEGER", nullable: false),
                    IdFormato_Media = table.Column<int>(type: "INTEGER", nullable: false),
                    CoverFile = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaFiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VideoCategoryLocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titulo = table.Column<string>(type: "TEXT", nullable: true),
                    IdCategoria = table.Column<int>(type: "INTEGER", nullable: false),
                    Categoria = table.Column<string>(type: "TEXT", nullable: true),
                    Tempo = table.Column<string>(type: "TEXT", nullable: true),
                    FileUrl = table.Column<string>(type: "TEXT", nullable: true),
                    Autor = table.Column<string>(type: "TEXT", nullable: true),
                    CoverFile = table.Column<string>(type: "TEXT", nullable: true),
                    VideoId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoCategoryLocations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VideoDetails",
                columns: table => new
                {
                    VideoId = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    ChannelTitle = table.Column<string>(type: "TEXT", nullable: true),
                    Duration = table.Column<string>(type: "TEXT", nullable: true),
                    PublicationDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Thumbnail = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoDetails", x => x.VideoId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "CategoryTypes");

            migrationBuilder.DropTable(
                name: "ImageCategoryLocations");

            migrationBuilder.DropTable(
                name: "Media_Formats");

            migrationBuilder.DropTable(
                name: "MediaFiles");

            migrationBuilder.DropTable(
                name: "VideoCategoryLocations");

            migrationBuilder.DropTable(
                name: "VideoDetails");
        }
    }
}
