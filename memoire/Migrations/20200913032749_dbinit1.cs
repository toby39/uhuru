using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace memoire.Migrations
{
    public partial class dbinit1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "client",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    noms = table.Column<string>(nullable: true),
                    sexe = table.Column<string>(nullable: true),
                    telephone = table.Column<string>(nullable: true),
                    solde = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_client", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "revendeur",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    noms = table.Column<string>(nullable: true),
                    sexe = table.Column<string>(nullable: true),
                    telephone = table.Column<string>(nullable: true),
                    solde = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_revendeur", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "approvisionement",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    numero = table.Column<string>(nullable: true),
                    date = table.Column<DateTime>(nullable: false),
                    quantite = table.Column<int>(nullable: false),
                    unite = table.Column<string>(nullable: true),
                    Revendeurid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_approvisionement", x => x.id);
                    table.ForeignKey(
                        name: "FK_approvisionement_revendeur_Revendeurid",
                        column: x => x.Revendeurid,
                        principalTable: "revendeur",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_approvisionement_Revendeurid",
                table: "approvisionement",
                column: "Revendeurid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "approvisionement");

            migrationBuilder.DropTable(
                name: "client");

            migrationBuilder.DropTable(
                name: "revendeur");
        }
    }
}
