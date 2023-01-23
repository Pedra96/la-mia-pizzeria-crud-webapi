using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaMiaPizzeria1.Migrations
{
    /// <inheritdoc />
    public partial class removedtagkey1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategoriaName",
                table: "CategoriePizze",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "CategoriaId",
                table: "CategoriePizze",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "CategoriePizze",
                newName: "CategoriaName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CategoriePizze",
                newName: "CategoriaId");
        }
    }
}
