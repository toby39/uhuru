using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace memoire.Migrations
{
    public partial class dbinit2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "vente",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    numero = table.Column<string>(nullable: true),
                    date = table.Column<DateTime>(nullable: false),
                    quantite = table.Column<int>(nullable: false),
                    unite = table.Column<string>(nullable: true),
                    Revendeurid = table.Column<int>(nullable: false),
                    Clientid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vente", x => x.id);
                    table.ForeignKey(
                        name: "FK_vente_client_Clientid",
                        column: x => x.Clientid,
                        principalTable: "client",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_vente_revendeur_Revendeurid",
                        column: x => x.Revendeurid,
                        principalTable: "revendeur",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_vente_Clientid",
                table: "vente",
                column: "Clientid");

            migrationBuilder.CreateIndex(
                name: "IX_vente_Revendeurid",
                table: "vente",
                column: "Revendeurid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "vente");
        }
    }
}
