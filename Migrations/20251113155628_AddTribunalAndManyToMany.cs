using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaTitulos.Migrations
{
    /// <inheritdoc />
    public partial class AddTribunalAndManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MiembroTribunal",
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
                    table.PrimaryKey("PK_MiembroTribunal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MiembroTribunalSolicitud",
                columns: table => new
                {
                    MiembrosTribunalId = table.Column<int>(type: "int", nullable: false),
                    SolicitudesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MiembroTribunalSolicitud", x => new { x.MiembrosTribunalId, x.SolicitudesId });
                    table.ForeignKey(
                        name: "FK_MiembroTribunalSolicitud_MiembroTribunal_MiembrosTribunalId",
                        column: x => x.MiembrosTribunalId,
                        principalTable: "MiembroTribunal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MiembroTribunalSolicitud_Solicitudes_SolicitudesId",
                        column: x => x.SolicitudesId,
                        principalTable: "Solicitudes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MiembroTribunalSolicitud_SolicitudesId",
                table: "MiembroTribunalSolicitud",
                column: "SolicitudesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MiembroTribunalSolicitud");

            migrationBuilder.DropTable(
                name: "MiembroTribunal");
        }
    }
}
