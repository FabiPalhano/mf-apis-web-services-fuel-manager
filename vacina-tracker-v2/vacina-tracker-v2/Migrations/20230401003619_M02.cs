using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vacina_tracker_v2.Migrations
{
    /// <inheritdoc />
    public partial class M02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CPF",
                table: "Perfil Usuário Responsável");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CPF",
                table: "Perfil Usuário Responsável",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
