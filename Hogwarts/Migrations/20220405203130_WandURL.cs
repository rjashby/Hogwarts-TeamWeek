using Microsoft.EntityFrameworkCore.Migrations;

namespace Hogwarts.Migrations
{
    public partial class WandURL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WandURL",
                table: "Students",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WandURL",
                table: "Students");
        }
    }
}
