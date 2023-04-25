using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vacina_tracker_v3.Migrations
{
    /// <inheritdoc />
    public partial class M01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NomeMembroFamilia",
                table: "Membros",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");            

            migrationBuilder.CreateTable(
                name: "Usuário",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuário", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vacinas Membros",
                columns: table => new
                {
                    MembroId = table.Column<int>(type: "int", nullable: false),
                    VacinaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacinas Membros", x => new { x.VacinaId, x.MembroId });
                    table.ForeignKey(
                        name: "FK_Vacinas Membros_Membros_MembroId",
                        column: x => x.MembroId,
                        principalTable: "Membros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vacinas Membros_Vacinas_VacinaId",
                        column: x => x.VacinaId,
                        principalTable: "Vacinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vacinas Membros_MembroId",
                table: "Vacinas Membros",
                column: "MembroId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
           migrationBuilder.DropTable(
                name: "Usuário");

            migrationBuilder.DropTable(
                name: "Vacinas Membros");

            migrationBuilder.AlterColumn<string>(
                name: "NomeMembroFamilia",
                table: "Membros",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);
        }
    }
}
