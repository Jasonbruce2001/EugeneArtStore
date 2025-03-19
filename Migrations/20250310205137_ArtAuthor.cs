using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EugeneArtStore.Migrations
{
    public partial class ArtAuthor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AuthorId",
                table: "Artworks",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Artworks_AuthorId",
                table: "Artworks",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Artworks_AspNetUsers_AuthorId",
                table: "Artworks",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artworks_AspNetUsers_AuthorId",
                table: "Artworks");

            migrationBuilder.DropIndex(
                name: "IX_Artworks_AuthorId",
                table: "Artworks");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Artworks");
        }
    }
}
