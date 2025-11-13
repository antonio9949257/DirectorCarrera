using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaTitulos.Migrations
{
    /// <inheritdoc />
    public partial class AddCalificacionFinalToSolicitud : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "CalificacionFinal",
                table: "Solicitudes",
                type: "decimal(18,2)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CalificacionFinal",
                table: "Solicitudes");
        }
    }
}
