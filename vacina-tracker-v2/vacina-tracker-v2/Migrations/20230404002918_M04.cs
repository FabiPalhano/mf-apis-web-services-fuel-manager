using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vacina_tracker_v2.Migrations
{
    /// <inheritdoc />
    public partial class M04 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacinas Adicionadas_Perfil Usuário Responsável_ResponsavelId",
                table: "Vacinas Adicionadas");

            migrationBuilder.DropIndex(
                name: "IX_Vacinas Adicionadas_ResponsavelId",
                table: "Vacinas Adicionadas");

            migrationBuilder.DropColumn(
                name: "Local",
                table: "Vacinas Adicionadas");

            migrationBuilder.DropColumn(
                name: "ResponsavelId",
                table: "Vacinas Adicionadas");

            migrationBuilder.RenameColumn(
                name: "DataProximaAplicacao",
                table: "Vacinas Adicionadas",
                newName: "DataProxAplicacao");

            migrationBuilder.CreateTable(
                name: "Vacinas Usuários",
                columns: table => new
                {
                    VacinaId = table.Column<int>(type: "int", nullable: false),
                    ResponsavelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacinas Usuários", x => new { x.VacinaId, x.ResponsavelId });
                    table.ForeignKey(
                        name: "FK_Vacinas Usuários_Perfil Usuário Responsável_ResponsavelId",
                        column: x => x.ResponsavelId,
                        principalTable: "Perfil Usuário Responsável",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vacinas Usuários_Vacinas Adicionadas_VacinaId",
                        column: x => x.VacinaId,
                        principalTable: "Vacinas Adicionadas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vacinas Usuários_ResponsavelId",
                table: "Vacinas Usuários",
                column: "ResponsavelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vacinas Usuários");

            migrationBuilder.RenameColumn(
                name: "DataProxAplicacao",
                table: "Vacinas Adicionadas",
                newName: "DataProximaAplicacao");

            migrationBuilder.AddColumn<string>(
                name: "Local",
                table: "Vacinas Adicionadas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ResponsavelId",
                table: "Vacinas Adicionadas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Vacinas Adicionadas_ResponsavelId",
                table: "Vacinas Adicionadas",
                column: "ResponsavelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vacinas Adicionadas_Perfil Usuário Responsável_ResponsavelId",
                table: "Vacinas Adicionadas",
                column: "ResponsavelId",
                principalTable: "Perfil Usuário Responsável",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
