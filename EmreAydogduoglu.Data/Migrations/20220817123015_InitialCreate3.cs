using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmreAydogduoglu.Data.Migrations
{
    public partial class InitialCreate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Thumbnail",
                table: "Articles");

            migrationBuilder.AddColumn<string>(
                name: "ThumbnailName",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ThumbnailName",
                table: "Articles");

            migrationBuilder.AddColumn<string>(
                name: "Thumbnail",
                table: "Articles",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");
        }
    }
}
