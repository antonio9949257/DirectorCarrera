using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaTitulos.Migrations
{
    /// <inheritdoc />
    public partial class AddObservacionesToSolicitud : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Observaciones",
                table: "Solicitudes",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Observaciones",
                table: "Solicitudes");
        }
    }
}
