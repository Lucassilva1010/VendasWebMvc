using Microsoft.EntityFrameworkCore.Migrations;

namespace VendasWebMvc.Migrations
{
    public partial class NovaChaveEstrangeira : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendedor_Departamentoo_DepartamentoId",
                table: "Vendedor");

            migrationBuilder.AlterColumn<int>(
                name: "DepartamentoId",
                table: "Vendedor",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendedor_Departamentoo_DepartamentoId",
                table: "Vendedor",
                column: "DepartamentoId",
                principalTable: "Departamentoo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendedor_Departamentoo_DepartamentoId",
                table: "Vendedor");

            migrationBuilder.AlterColumn<int>(
                name: "DepartamentoId",
                table: "Vendedor",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Vendedor_Departamentoo_DepartamentoId",
                table: "Vendedor",
                column: "DepartamentoId",
                principalTable: "Departamentoo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
