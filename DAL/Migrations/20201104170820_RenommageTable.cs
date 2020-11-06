using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class RenommageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Communes");

            migrationBuilder.CreateTable(
                name: "Scores",
                columns: table => new
                {
                    ScoreId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LibelleDepartement = table.Column<string>(nullable: true),
                    LibelleEpci = table.Column<string>(nullable: true),
                    LibelleRegion = table.Column<string>(nullable: true),
                    Population = table.Column<double>(nullable: false),
                    ScoreGlobalDep = table.Column<double>(nullable: false),
                    ScoreGlobalEpci = table.Column<double>(nullable: false),
                    ScoreGlobalReg = table.Column<double>(nullable: false),
                    NomIris = table.Column<string>(nullable: true),
                    CodeIris = table.Column<string>(nullable: true),
                    CodeCommune = table.Column<string>(nullable: true),
                    CodeDepartement = table.Column<string>(nullable: true),
                    CodeEpci = table.Column<string>(nullable: true),
                    CodeRegion = table.Column<int>(nullable: false),
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
                    table.PrimaryKey("PK_Scores", x => x.ScoreId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Scores");

            migrationBuilder.CreateTable(
                name: "Communes",
                columns: table => new
                {
                    CommuneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CodeIris = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    GeoShape = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    GrandQuart = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    LibelleDepartement = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    LibelleEpci = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    LibelleRegion = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Nom = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    NomIris = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    NumeroDepartement = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    NumeroEpci = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    NumeroRegion = table.Column<int>(type: "int", nullable: false),
                    Population = table.Column<double>(type: "double", nullable: false),
                    ScoreAccesInfoDep = table.Column<double>(type: "double", nullable: false),
                    ScoreAccesInfoEpci = table.Column<double>(type: "double", nullable: false),
                    ScoreAccesInfoReg = table.Column<double>(type: "double", nullable: false),
                    ScoreAccesInterDep = table.Column<double>(type: "double", nullable: false),
                    ScoreAccesInterEpci = table.Column<double>(type: "double", nullable: false),
                    ScoreAccesInterReg = table.Column<double>(type: "double", nullable: false),
                    ScoreCompAdminDep = table.Column<double>(type: "double", nullable: false),
                    ScoreCompAdminEpci = table.Column<double>(type: "double", nullable: false),
                    ScoreCompAdminReg = table.Column<double>(type: "double", nullable: false),
                    ScoreCompNumDep = table.Column<double>(type: "double", nullable: false),
                    ScoreCompNumEpci = table.Column<double>(type: "double", nullable: false),
                    ScoreCompNumReg = table.Column<double>(type: "double", nullable: false),
                    ScoreGlobalAccesDep = table.Column<double>(type: "double", nullable: false),
                    ScoreGlobalAccesEpci = table.Column<double>(type: "double", nullable: false),
                    ScoreGlobalAccesReg = table.Column<double>(type: "double", nullable: false),
                    ScoreGlobalCompDep = table.Column<double>(type: "double", nullable: false),
                    ScoreGlobalCompEpci = table.Column<double>(type: "double", nullable: false),
                    ScoreGlobalCompReg = table.Column<double>(type: "double", nullable: false),
                    ScoreGlobalDep = table.Column<double>(type: "double", nullable: false),
                    ScoreGlobalEpci = table.Column<double>(type: "double", nullable: false),
                    ScoreGlobalReg = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Communes", x => x.CommuneId);
                });
        }
    }
}
