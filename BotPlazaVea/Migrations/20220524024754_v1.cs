using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BotPlazaVea.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Urls",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    url = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urls", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombreProducto = table.Column<string>(type: "text", nullable: true),
                    precioReg = table.Column<decimal>(type: "numeric", nullable: false),
                    precioOferta = table.Column<decimal>(type: "numeric", nullable: false),
                    proveedor = table.Column<string>(type: "text", nullable: true),
                    categoria = table.Column<string>(type: "text", nullable: true),
                    subcategoria = table.Column<string>(type: "text", nullable: true),
                    tipo = table.Column<string>(type: "text", nullable: true),
                    subtipo = table.Column<string>(type: "text", nullable: true),
                    imagenUrl = table.Column<string>(type: "text", nullable: true),
                    idUrl = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.id);
                    table.ForeignKey(
                        name: "FK_URL_1",
                        column: x => x.idUrl,
                        principalTable: "Urls",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Productos_idUrl",
                table: "Productos",
                column: "idUrl",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Urls_url",
                table: "Urls",
                column: "url",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Urls");
        }
    }
}
