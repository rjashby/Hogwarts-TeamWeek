using Microsoft.EntityFrameworkCore.Migrations;

namespace Hogwarts.Migrations
{
    public partial class AddScaleProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Owl",
                table: "Students",
                newName: "Scale");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Scale",
                table: "Students",
                newName: "Owl");
        }
    }
}
