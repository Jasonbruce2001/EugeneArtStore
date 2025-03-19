using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EugeneArtStore.Migrations
{
    public partial class alterDateName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateFinished",
                table: "Artworks",
                newName: "DatePosted");

            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "Artworks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Likes",
                table: "Artworks");

            migrationBuilder.RenameColumn(
                name: "DatePosted",
                table: "Artworks",
                newName: "DateFinished");
        }
    }
}
