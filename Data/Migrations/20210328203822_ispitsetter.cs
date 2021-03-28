using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentMS.Data.Migrations
{
    public partial class ispitsetter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Naziv",
                table: "Ispiti",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Naziv",
                table: "Ispiti");
        }
    }
}
