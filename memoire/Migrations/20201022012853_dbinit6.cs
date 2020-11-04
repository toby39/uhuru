using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace memoire.Migrations
{
    public partial class dbinit6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "quantite",
                table: "vente");

            migrationBuilder.DropColumn(
                name: "unite",
                table: "vente");

            migrationBuilder.AddColumn<string>(
                name: "paquet",
                table: "vente",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "stat",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stat", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "stat");

            migrationBuilder.DropColumn(
                name: "paquet",
                table: "vente");

            migrationBuilder.AddColumn<int>(
                name: "quantite",
                table: "vente",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "unite",
                table: "vente",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
