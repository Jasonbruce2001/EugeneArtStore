using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EugeneArtStore.Migrations
{
    public partial class productIdAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Reviews");
        }
    }
}
