using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionDuCompresseur.Migrations
{
    public partial class test3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FicheCompresseurs_CompresseurFiliales_CompFilialeID",
                table: "FicheCompresseurs");

            migrationBuilder.DropIndex(
                name: "IX_FicheCompresseurs_CompFilialeID",
                table: "FicheCompresseurs");

            migrationBuilder.CreateIndex(
                name: "IX_CompresseurFiliales_CompresseurID",
                table: "CompresseurFiliales",
                column: "CompresseurID");

            migrationBuilder.AddForeignKey(
                name: "FK_CompresseurFiliales_FicheCompresseurs_CompresseurID",
                table: "CompresseurFiliales",
                column: "CompresseurID",
                principalTable: "FicheCompresseurs",
                principalColumn: "CompresseurID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompresseurFiliales_FicheCompresseurs_CompresseurID",
                table: "CompresseurFiliales");

            migrationBuilder.DropIndex(
                name: "IX_CompresseurFiliales_CompresseurID",
                table: "CompresseurFiliales");

            migrationBuilder.CreateIndex(
                name: "IX_FicheCompresseurs_CompFilialeID",
                table: "FicheCompresseurs",
                column: "CompFilialeID");

            migrationBuilder.AddForeignKey(
                name: "FK_FicheCompresseurs_CompresseurFiliales_CompFilialeID",
                table: "FicheCompresseurs",
                column: "CompFilialeID",
                principalTable: "CompresseurFiliales",
                principalColumn: "CompFilialeID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
