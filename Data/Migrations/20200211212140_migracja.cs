using Microsoft.EntityFrameworkCore.Migrations;

namespace Terminarz.Data.Migrations
{
    public partial class migracja : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Happenings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Happenings",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Happenings");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Happenings");
        }
    }
}
