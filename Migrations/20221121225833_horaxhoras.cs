using Microsoft.EntityFrameworkCore.Migrations;

namespace hora_Komdelli.Migrations
{
    public partial class horaxhoras : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "corte_executado",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    primeiro = table.Column<string>(type: "TEXT", nullable: true),
                    segundo = table.Column<string>(type: "TEXT", nullable: true),
                    terceiro = table.Column<string>(type: "TEXT", nullable: true),
                    quarto = table.Column<string>(type: "TEXT", nullable: true),
                    quinto = table.Column<string>(type: "TEXT", nullable: true),
                    sexto = table.Column<string>(type: "TEXT", nullable: true),
                    setimo = table.Column<string>(type: "TEXT", nullable: true),
                    oitavo = table.Column<string>(type: "TEXT", nullable: true),
                    nono = table.Column<string>(type: "TEXT", nullable: true),
                    decimo = table.Column<string>(type: "TEXT", nullable: true),
                    decimo_primeiro = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_corte_executado", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "corte_planejado",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    primeiro = table.Column<string>(type: "TEXT", nullable: true),
                    segundo = table.Column<string>(type: "TEXT", nullable: true),
                    terceiro = table.Column<string>(type: "TEXT", nullable: true),
                    quarto = table.Column<string>(type: "TEXT", nullable: true),
                    quinto = table.Column<string>(type: "TEXT", nullable: true),
                    sexto = table.Column<string>(type: "TEXT", nullable: true),
                    setimo = table.Column<string>(type: "TEXT", nullable: true),
                    oitavo = table.Column<string>(type: "TEXT", nullable: true),
                    nono = table.Column<string>(type: "TEXT", nullable: true),
                    decimo = table.Column<string>(type: "TEXT", nullable: true),
                    decimo_primeiro = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_corte_planejado", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "op_executado",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    primeiro = table.Column<string>(type: "TEXT", nullable: true),
                    segundo = table.Column<string>(type: "TEXT", nullable: true),
                    terceiro = table.Column<string>(type: "TEXT", nullable: true),
                    quarto = table.Column<string>(type: "TEXT", nullable: true),
                    quinto = table.Column<string>(type: "TEXT", nullable: true),
                    sexto = table.Column<string>(type: "TEXT", nullable: true),
                    setimo = table.Column<string>(type: "TEXT", nullable: true),
                    oitavo = table.Column<string>(type: "TEXT", nullable: true),
                    nono = table.Column<string>(type: "TEXT", nullable: true),
                    decimo = table.Column<string>(type: "TEXT", nullable: true),
                    decimo_primeiro = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_op_executado", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "op_planejado",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    primeiro = table.Column<string>(type: "TEXT", nullable: true),
                    segundo = table.Column<string>(type: "TEXT", nullable: true),
                    terceiro = table.Column<string>(type: "TEXT", nullable: true),
                    quarto = table.Column<string>(type: "TEXT", nullable: true),
                    quinto = table.Column<string>(type: "TEXT", nullable: true),
                    sexto = table.Column<string>(type: "TEXT", nullable: true),
                    setimo = table.Column<string>(type: "TEXT", nullable: true),
                    oitavo = table.Column<string>(type: "TEXT", nullable: true),
                    nono = table.Column<string>(type: "TEXT", nullable: true),
                    decimo = table.Column<string>(type: "TEXT", nullable: true),
                    decimo_primeiro = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_op_planejado", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "parada_corte",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    hora_inicio = table.Column<string>(type: "TEXT", nullable: true),
                    hora_final = table.Column<string>(type: "TEXT", nullable: true),
                    processo = table.Column<string>(type: "TEXT", nullable: true),
                    ordem = table.Column<string>(type: "TEXT", nullable: true),
                    justificativa = table.Column<string>(type: "TEXT", nullable: true),
                    duracao = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parada_corte", x => x.id);
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

            migrationBuilder.DropTable(
                name: "parada_corte");
        }
    }
}
