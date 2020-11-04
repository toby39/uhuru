using Microsoft.EntityFrameworkCore.Migrations;

namespace memoire.Migrations
{
    public partial class dbinit10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "vente",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "password",
                table: "vente");
        }
    }
}
