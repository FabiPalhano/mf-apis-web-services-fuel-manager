using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vacina_tracker_v2.Migrations
{
    /// <inheritdoc />
    public partial class M03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vacinas");

            migrationBuilder.RenameColumn(
                name: "IdResponsavel",
                table: "Perfil Usuário Responsável",
                newName: "Id");

            migrationBuilder.CreateTable(
                name: "Vacinas Adicionadas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeVacina = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataAplicacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Dose = table.Column<int>(type: "int", nullable: false),
                    Local = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataProximaAplicacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ResponsavelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacinas Adicionadas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vacinas Adicionadas_Perfil Usuário Responsável_ResponsavelId",
                        column: x => x.ResponsavelId,
                        principalTable: "Perfil Usuário Responsável",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LinkDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Href = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Metodo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResponsavelId = table.Column<int>(type: "int", nullable: true),
                    VacinaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkDto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LinkDto_Perfil Usuário Responsável_ResponsavelId",
                        column: x => x.ResponsavelId,
                        principalTable: "Perfil Usuário Responsável",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LinkDto_Vacinas Adicionadas_VacinaId",
                        column: x => x.VacinaId,
                        principalTable: "Vacinas Adicionadas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LinkDto_ResponsavelId",
                table: "LinkDto",
                column: "ResponsavelId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkDto_VacinaId",
                table: "LinkDto",
                column: "VacinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacinas Adicionadas_ResponsavelId",
                table: "Vacinas Adicionadas",
                column: "ResponsavelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LinkDto");

            migrationBuilder.DropTable(
                name: "Vacinas Adicionadas");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Perfil Usuário Responsável",
                newName: "IdResponsavel");

            migrationBuilder.CreateTable(
                name: "Vacinas",
                columns: table => new
                {
                    IdVacina = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResponsavelId = table.Column<int>(type: "int", nullable: false),
                    DataAplicacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataProximaAplicacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Local = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeVacina = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroDose = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacinas", x => x.IdVacina);
                    table.ForeignKey(
                        name: "FK_Vacinas_Perfil Usuário Responsável_ResponsavelId",
                        column: x => x.ResponsavelId,
                        principalTable: "Perfil Usuário Responsável",
                        principalColumn: "IdResponsavel",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vacinas_ResponsavelId",
                table: "Vacinas",
                column: "ResponsavelId");
        }
    }
}
