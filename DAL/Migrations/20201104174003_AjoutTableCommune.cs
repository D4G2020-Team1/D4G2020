using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AjoutTableCommune : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CodeCommune",
                table: "Scores",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Communes",
                columns: table => new
                {
                    CodeInsee = table.Column<string>(maxLength: 10, nullable: false),
                    NomCommune = table.Column<string>(nullable: true),
                    CodePostal = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Communes", x => x.CodeInsee);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Scores_CodeCommune",
                table: "Scores",
                column: "CodeCommune");

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_Communes_CodeCommune",
                table: "Scores",
                column: "CodeCommune",
                principalTable: "Communes",
                principalColumn: "CodeInsee",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scores_Communes_CodeCommune",
                table: "Scores");

            migrationBuilder.DropTable(
                name: "Communes");

            migrationBuilder.DropIndex(
                name: "IX_Scores_CodeCommune",
                table: "Scores");

            migrationBuilder.AlterColumn<string>(
                name: "CodeCommune",
                table: "Scores",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
