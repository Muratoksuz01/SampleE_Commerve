using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Ticaret.Migrations
{
    /// <inheritdoc />
    public partial class YeniGuncelleme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Uruns_Kategoris_KategoriID",
                table: "Uruns");

            migrationBuilder.AlterColumn<int>(
                name: "SatisFiyat",
                table: "Uruns",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<int>(
                name: "KategoriID",
                table: "Uruns",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AlisFiyat",
                table: "Uruns",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AddColumn<bool>(
                name: "Durum",
                table: "Departmans",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Uruns_Kategoris_KategoriID",
                table: "Uruns",
                column: "KategoriID",
                principalTable: "Kategoris",
                principalColumn: "KategoriID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Uruns_Kategoris_KategoriID",
                table: "Uruns");

            migrationBuilder.DropColumn(
                name: "Durum",
                table: "Departmans");

            migrationBuilder.AlterColumn<decimal>(
                name: "SatisFiyat",
                table: "Uruns",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "KategoriID",
                table: "Uruns",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "AlisFiyat",
                table: "Uruns",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Uruns_Kategoris_KategoriID",
                table: "Uruns",
                column: "KategoriID",
                principalTable: "Kategoris",
                principalColumn: "KategoriID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
