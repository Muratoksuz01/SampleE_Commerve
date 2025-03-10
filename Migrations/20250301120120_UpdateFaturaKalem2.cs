using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Ticaret.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFaturaKalem2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FaturaKalems_Faturas_FaturalarFaturaID",
                table: "FaturaKalems");

            migrationBuilder.DropIndex(
                name: "IX_FaturaKalems_FaturalarFaturaID",
                table: "FaturaKalems");

            migrationBuilder.DropColumn(
                name: "FaturalarFaturaID",
                table: "FaturaKalems");

            migrationBuilder.CreateIndex(
                name: "IX_FaturaKalems_Faturaid",
                table: "FaturaKalems",
                column: "Faturaid");

            migrationBuilder.AddForeignKey(
                name: "FK_FaturaKalems_Faturas_Faturaid",
                table: "FaturaKalems",
                column: "Faturaid",
                principalTable: "Faturas",
                principalColumn: "FaturaID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FaturaKalems_Faturas_Faturaid",
                table: "FaturaKalems");

            migrationBuilder.DropIndex(
                name: "IX_FaturaKalems_Faturaid",
                table: "FaturaKalems");

            migrationBuilder.AddColumn<int>(
                name: "FaturalarFaturaID",
                table: "FaturaKalems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FaturaKalems_FaturalarFaturaID",
                table: "FaturaKalems",
                column: "FaturalarFaturaID");

            migrationBuilder.AddForeignKey(
                name: "FK_FaturaKalems_Faturas_FaturalarFaturaID",
                table: "FaturaKalems",
                column: "FaturalarFaturaID",
                principalTable: "Faturas",
                principalColumn: "FaturaID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
