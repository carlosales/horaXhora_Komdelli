using Microsoft.EntityFrameworkCore.Migrations;

namespace hora_Komdelli.Migrations
{
    public partial class MyFirst : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "corte_executado",
                columns: table => new
                {
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "corte_planejado",
                columns: table => new
                {
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "op_executado",
                columns: table => new
                {
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "op_planejado",
                columns: table => new
                {
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "corte_executado");

            migrationBuilder.DropTable(
                name: "corte_planejado");

            migrationBuilder.DropTable(
                name: "op_executado");

            migrationBuilder.DropTable(
                name: "op_planejado");
        }
    }
}
