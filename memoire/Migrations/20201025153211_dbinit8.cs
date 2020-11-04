using Microsoft.EntityFrameworkCore.Migrations;

namespace memoire.Migrations
{
    public partial class dbinit8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "desigantion",
                table: "tarif");

            migrationBuilder.AddColumn<string>(
                name: "desciption",
                table: "tarif",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "designation",
                table: "tarif",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "desciption",
                table: "tarif");

            migrationBuilder.DropColumn(
                name: "designation",
                table: "tarif");

            migrationBuilder.AddColumn<string>(
                name: "desigantion",
                table: "tarif",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
