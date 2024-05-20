using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EdamanFluentApi.Migrations.Youtube
{
    /// <inheritdoc />
    public partial class Two : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_MediaFiles_IdFormato_Media",
                table: "MediaFiles",
                column: "IdFormato_Media");

            migrationBuilder.CreateIndex(
                name: "IX_MediaFiles_IdGenero",
                table: "MediaFiles",
                column: "IdGenero");

            migrationBuilder.AddForeignKey(
                name: "FK_MediaFiles_Categorias_IdGenero",
                table: "MediaFiles",
                column: "IdGenero",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MediaFiles_Media_Formats_IdFormato_Media",
                table: "MediaFiles",
                column: "IdFormato_Media",
                principalTable: "Media_Formats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MediaFiles_Categorias_IdGenero",
                table: "MediaFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_MediaFiles_Media_Formats_IdFormato_Media",
                table: "MediaFiles");

            migrationBuilder.DropIndex(
                name: "IX_MediaFiles_IdFormato_Media",
                table: "MediaFiles");

            migrationBuilder.DropIndex(
                name: "IX_MediaFiles_IdGenero",
                table: "MediaFiles");
        }
    }
}
