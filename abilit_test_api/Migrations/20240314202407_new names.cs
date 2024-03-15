using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace abilit_test_api.Migrations
{
    /// <inheritdoc />
    public partial class newnames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Generos",
                table: "Generos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Funcionarios",
                table: "Funcionarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dependentes",
                table: "Dependentes");

            migrationBuilder.RenameTable(
                name: "Generos",
                newName: "GenerosTB");

            migrationBuilder.RenameTable(
                name: "Funcionarios",
                newName: "FuncionariosTB");

            migrationBuilder.RenameTable(
                name: "Dependentes",
                newName: "DependentesTB");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GenerosTB",
                table: "GenerosTB",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FuncionariosTB",
                table: "FuncionariosTB",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DependentesTB",
                table: "DependentesTB",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GenerosTB",
                table: "GenerosTB");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FuncionariosTB",
                table: "FuncionariosTB");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DependentesTB",
                table: "DependentesTB");

            migrationBuilder.RenameTable(
                name: "GenerosTB",
                newName: "Generos");

            migrationBuilder.RenameTable(
                name: "FuncionariosTB",
                newName: "Funcionarios");

            migrationBuilder.RenameTable(
                name: "DependentesTB",
                newName: "Dependentes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Generos",
                table: "Generos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Funcionarios",
                table: "Funcionarios",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dependentes",
                table: "Dependentes",
                column: "Id");
        }
    }
}
