using Microsoft.EntityFrameworkCore.Migrations;

namespace VendasWebMvc.Migrations
{
    public partial class povoandoBanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendedor_Departamento_DepartamentoId",
                table: "Vendedor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departamento",
                table: "Departamento");

            migrationBuilder.RenameTable(
                name: "Departamento",
                newName: "Departamentoo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departamentoo",
                table: "Departamentoo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendedor_Departamentoo_DepartamentoId",
                table: "Vendedor",
                column: "DepartamentoId",
                principalTable: "Departamentoo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendedor_Departamentoo_DepartamentoId",
                table: "Vendedor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departamentoo",
                table: "Departamentoo");

            migrationBuilder.RenameTable(
                name: "Departamentoo",
                newName: "Departamento");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departamento",
                table: "Departamento",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendedor_Departamento_DepartamentoId",
                table: "Vendedor",
                column: "DepartamentoId",
                principalTable: "Departamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
