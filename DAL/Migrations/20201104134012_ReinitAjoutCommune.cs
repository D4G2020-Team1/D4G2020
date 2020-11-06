using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class ReinitAjoutCommune : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departements");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.CreateTable(
                name: "Communes",
                columns: table => new
                {
                    CommuneId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(nullable: true),
                    LibelleDepartement = table.Column<string>(nullable: true),
                    LibelleEpci = table.Column<string>(nullable: true),
                    LibelleRegion = table.Column<string>(nullable: true),
                    Population = table.Column<double>(nullable: false),
                    ScoreGlobalDep = table.Column<double>(nullable: false),
                    ScoreGlobalEpci = table.Column<double>(nullable: false),
                    ScoreGlobalReg = table.Column<double>(nullable: false),
                    NomIris = table.Column<string>(nullable: true),
                    CodeIris = table.Column<int>(nullable: false),
                    NumeroDepartement = table.Column<int>(nullable: false),
                    NumeroEpci = table.Column<int>(nullable: false),
                    NumeroRegion = table.Column<int>(nullable: false),
                    GeoShape = table.Column<string>(nullable: true),
                    GrandQuart = table.Column<string>(nullable: true),
                    ScoreAccesInfoDep = table.Column<double>(nullable: false),
                    ScoreAccesInfoEpci = table.Column<double>(nullable: false),
                    ScoreAccesInfoReg = table.Column<double>(nullable: false),
                    ScoreAccesInterDep = table.Column<double>(nullable: false),
                    ScoreAccesInterEpci = table.Column<double>(nullable: false),
                    ScoreAccesInterReg = table.Column<double>(nullable: false),
                    ScoreCompAdminDep = table.Column<double>(nullable: false),
                    ScoreCompAdminEpci = table.Column<double>(nullable: false),
                    ScoreCompAdminReg = table.Column<double>(nullable: false),
                    ScoreCompNumDep = table.Column<double>(nullable: false),
                    ScoreCompNumEpci = table.Column<double>(nullable: false),
                    ScoreCompNumReg = table.Column<double>(nullable: false),
                    ScoreGlobalAccesDep = table.Column<double>(nullable: false),
                    ScoreGlobalAccesEpci = table.Column<double>(nullable: false),
                    ScoreGlobalAccesReg = table.Column<double>(nullable: false),
                    ScoreGlobalCompDep = table.Column<double>(nullable: false),
                    ScoreGlobalCompEpci = table.Column<double>(nullable: false),
                    ScoreGlobalCompReg = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Communes", x => x.CommuneId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Communes");

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    RegionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Libelle = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.RegionId);
                });

            migrationBuilder.CreateTable(
                name: "Departements",
                columns: table => new
                {
                    DepartementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Libelle = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    RegionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departements", x => x.DepartementId);
                    table.ForeignKey(
                        name: "FK_Departements_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "RegionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departements_RegionId",
                table: "Departements",
                column: "RegionId");
        }
    }
}
