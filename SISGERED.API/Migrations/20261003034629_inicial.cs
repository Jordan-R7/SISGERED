using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SISGERED.API.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administradores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cedula = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administradores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmpresasExternas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefono = table.Column<int>(type: "int", maxLength: 11, nullable: false),
                    NET = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresasExternas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Intervenciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_personal = table.Column<int>(type: "int", nullable: false),
                    ID_Empresaexterna = table.Column<int>(type: "int", nullable: false),
                    ID_Reporte = table.Column<int>(type: "int", nullable: false),
                    ID_Administrador = table.Column<int>(type: "int", nullable: false),
                    Fechainicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fechafin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaProgramada = table.Column<DateOnly>(type: "date", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prioridad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Intervenciones", x => x.Id);
                    table.CheckConstraint("CK_Intervencion_ResponsableExclusivo", "([ID_personal] IS NOT NULL AND [ID_Empresaexterna] IS NULL) OR ([ID_personal] IS NULL AND [ID_Empresaexterna] IS NOT NULL)");
                });

            migrationBuilder.CreateTable(
                name: "Personal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cedula = table.Column<int>(type: "int", maxLength: 11, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Telefono = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Cargo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConjuntosResidenciales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AdministradorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConjuntosResidenciales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConjuntosResidenciales_Administradores_AdministradorId",
                        column: x => x.AdministradorId,
                        principalTable: "Administradores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Residentes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cedula = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Apartamento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConjuntoResidencialId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Residentes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Residentes_ConjuntosResidenciales_ConjuntoResidencialId",
                        column: x => x.ConjuntoResidencialId,
                        principalTable: "ConjuntosResidenciales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ubicaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    TipoUbicacion = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Activa = table.Column<bool>(type: "bit", nullable: false),
                    ConjuntoResidencialId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ubicaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ubicaciones_ConjuntosResidenciales_ConjuntoResidencialId",
                        column: x => x.ConjuntoResidencialId,
                        principalTable: "ConjuntosResidenciales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Revisiones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoRevision = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EstadoRevision = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    FechaProgramada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaRealizacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    UbicacionId = table.Column<int>(type: "int", nullable: false),
                    PersonalId = table.Column<int>(type: "int", nullable: false),
                    IntervencionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Revisiones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Revisiones_Intervenciones_IntervencionId",
                        column: x => x.IntervencionId,
                        principalTable: "Intervenciones",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Revisiones_Personal_PersonalId",
                        column: x => x.PersonalId,
                        principalTable: "Personal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Revisiones_Ubicaciones_UbicacionId",
                        column: x => x.UbicacionId,
                        principalTable: "Ubicaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reportes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    FechaReporte = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UbicacionId = table.Column<int>(type: "int", nullable: false),
                    ResidenteId = table.Column<int>(type: "int", nullable: true),
                    PersonalId = table.Column<int>(type: "int", nullable: true),
                    RevisionId = table.Column<int>(type: "int", nullable: true),
                    IntervecionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reportes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reportes_Intervenciones_IntervecionId",
                        column: x => x.IntervecionId,
                        principalTable: "Intervenciones",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reportes_Personal_PersonalId",
                        column: x => x.PersonalId,
                        principalTable: "Personal",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reportes_Residentes_ResidenteId",
                        column: x => x.ResidenteId,
                        principalTable: "Residentes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reportes_Revisiones_RevisionId",
                        column: x => x.RevisionId,
                        principalTable: "Revisiones",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reportes_Ubicaciones_UbicacionId",
                        column: x => x.UbicacionId,
                        principalTable: "Ubicaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Administradores_Cedula",
                table: "Administradores",
                column: "Cedula",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConjuntosResidenciales_AdministradorId",
                table: "ConjuntosResidenciales",
                column: "AdministradorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reportes_IntervecionId",
                table: "Reportes",
                column: "IntervecionId");

            migrationBuilder.CreateIndex(
                name: "IX_Reportes_PersonalId",
                table: "Reportes",
                column: "PersonalId");

            migrationBuilder.CreateIndex(
                name: "IX_Reportes_ResidenteId",
                table: "Reportes",
                column: "ResidenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Reportes_RevisionId",
                table: "Reportes",
                column: "RevisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Reportes_UbicacionId",
                table: "Reportes",
                column: "UbicacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Residentes_ConjuntoResidencialId",
                table: "Residentes",
                column: "ConjuntoResidencialId");

            migrationBuilder.CreateIndex(
                name: "IX_Revisiones_IntervencionId",
                table: "Revisiones",
                column: "IntervencionId");

            migrationBuilder.CreateIndex(
                name: "IX_Revisiones_PersonalId",
                table: "Revisiones",
                column: "PersonalId");

            migrationBuilder.CreateIndex(
                name: "IX_Revisiones_UbicacionId",
                table: "Revisiones",
                column: "UbicacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Ubicaciones_ConjuntoResidencialId",
                table: "Ubicaciones",
                column: "ConjuntoResidencialId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpresasExternas");

            migrationBuilder.DropTable(
                name: "Reportes");

            migrationBuilder.DropTable(
                name: "Residentes");

            migrationBuilder.DropTable(
                name: "Revisiones");

            migrationBuilder.DropTable(
                name: "Intervenciones");

            migrationBuilder.DropTable(
                name: "Personal");

            migrationBuilder.DropTable(
                name: "Ubicaciones");

            migrationBuilder.DropTable(
                name: "ConjuntosResidenciales");

            migrationBuilder.DropTable(
                name: "Administradores");
        }
    }
}
