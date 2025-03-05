using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EugeneArtStore.Migrations
{
    public partial class updatedIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "AccountAge",
                table: "AspNetUsers",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountAge",
                table: "AspNetUsers");
        }
    }
}
