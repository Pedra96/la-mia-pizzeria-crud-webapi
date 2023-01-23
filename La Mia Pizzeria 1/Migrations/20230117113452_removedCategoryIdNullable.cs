using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaMiaPizzeria1.Migrations
{
    /// <inheritdoc />
    public partial class removedCategoryIdNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizze_CategoriePizze_CategoriaId",
                table: "Pizze");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "Pizze",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pizze_CategoriePizze_CategoriaId",
                table: "Pizze",
                column: "CategoriaId",
                principalTable: "CategoriePizze",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizze_CategoriePizze_CategoriaId",
                table: "Pizze");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "Pizze",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizze_CategoriePizze_CategoriaId",
                table: "Pizze",
                column: "CategoriaId",
                principalTable: "CategoriePizze",
                principalColumn: "Id");
        }
    }
}
