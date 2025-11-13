using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaTitulos.Migrations
{
    /// <inheritdoc />
    public partial class AddTutorAndLinkToSolicitud : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TutorId",
                table: "Solicitudes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tutor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCompleto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Especialidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tutor", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Solicitudes_TutorId",
                table: "Solicitudes",
                column: "TutorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitudes_Tutor_TutorId",
                table: "Solicitudes",
                column: "TutorId",
                principalTable: "Tutor",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Solicitudes_Tutor_TutorId",
                table: "Solicitudes");

            migrationBuilder.DropTable(
                name: "Tutor");

            migrationBuilder.DropIndex(
                name: "IX_Solicitudes_TutorId",
                table: "Solicitudes");

            migrationBuilder.DropColumn(
                name: "TutorId",
                table: "Solicitudes");
        }
    }
}
