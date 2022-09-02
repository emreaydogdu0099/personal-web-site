using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmreAydogduoglu.Data.Migrations
{
    public partial class InitialCreate6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Job",
                table: "Persons",
                newName: "Title");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Persons",
                newName: "Job");
        }
    }
}
