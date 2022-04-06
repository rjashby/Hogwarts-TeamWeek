using Microsoft.EntityFrameworkCore.Migrations;

namespace Hogwarts.Migrations
{
    public partial class UpdateStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Books",
                table: "Students",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cauldron",
                table: "Students",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Owl",
                table: "Students",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phials",
                table: "Students",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tools",
                table: "Students",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Books",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Cauldron",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Owl",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Phials",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Tools",
                table: "Students");
        }
    }
}
