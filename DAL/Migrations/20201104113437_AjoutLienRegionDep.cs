using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AjoutLienRegionDep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Departements_RegionId",
                table: "Departements",
                column: "RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departements_Regions_RegionId",
                table: "Departements",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "RegionId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departements_Regions_RegionId",
                table: "Departements");

            migrationBuilder.DropIndex(
                name: "IX_Departements_RegionId",
                table: "Departements");
        }
    }
}
