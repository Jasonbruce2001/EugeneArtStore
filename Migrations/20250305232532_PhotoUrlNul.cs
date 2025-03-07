using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EugeneArtStore.Migrations
{
    public partial class PhotoUrlNul : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhotoUrl",
                table: "Products",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "PhotoUrl",
                keyValue: null,
                column: "PhotoUrl",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "PhotoUrl",
                table: "Products",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
