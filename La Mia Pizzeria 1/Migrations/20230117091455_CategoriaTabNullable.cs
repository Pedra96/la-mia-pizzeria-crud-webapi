using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaMiaPizzeria1.Migrations
{
    /// <inheritdoc />
    public partial class CategoriaTabNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Pizze",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CategoriePizze",
                columns: table => new
                {
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoriaName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriePizze", x => x.CategoriaId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pizze_CategoriaId",
                table: "Pizze",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizze_CategoriePizze_CategoriaId",
                table: "Pizze",
                column: "CategoriaId",
                principalTable: "CategoriePizze",
                principalColumn: "CategoriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizze_CategoriePizze_CategoriaId",
                table: "Pizze");

            migrationBuilder.DropTable(
                name: "CategoriePizze");

            migrationBuilder.DropIndex(
                name: "IX_Pizze_CategoriaId",
                table: "Pizze");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Pizze");
        }
    }
}
