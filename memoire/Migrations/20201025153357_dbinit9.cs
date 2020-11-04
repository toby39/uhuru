using Microsoft.EntityFrameworkCore.Migrations;

namespace memoire.Migrations
{
    public partial class dbinit9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "desciption",
                table: "tarif");

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "tarif",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "description",
                table: "tarif");

            migrationBuilder.AddColumn<string>(
                name: "desciption",
                table: "tarif",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
