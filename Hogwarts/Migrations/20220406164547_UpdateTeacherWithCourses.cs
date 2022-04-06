using Microsoft.EntityFrameworkCore.Migrations;

namespace Hogwarts.Migrations
{
    public partial class UpdateTeacherWithCourses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CourseId",
                table: "Teachers",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CourseName",
                table: "Teachers",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "CourseName",
                table: "Teachers");
        }
    }
}
