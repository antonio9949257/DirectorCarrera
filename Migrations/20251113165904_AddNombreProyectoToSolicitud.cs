using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaTitulos.Migrations
{
    /// <inheritdoc />
    public partial class AddNombreProyectoToSolicitud : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NombreProyecto",
                table: "Solicitudes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NombreProyecto",
                table: "Solicitudes");
        }
    }
}
