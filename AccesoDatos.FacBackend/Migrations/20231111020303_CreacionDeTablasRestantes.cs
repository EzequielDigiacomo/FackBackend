using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccesoDatos.FacBackend.Migrations
{
    /// <inheritdoc />
    public partial class CreacionDeTablasRestantes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MadreDeAtletas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAtleta = table.Column<int>(type: "int", nullable: false),
                    NombreMadre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ApellidoMadre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    DniMadre = table.Column<long>(type: "bigint", maxLength: 99999999, nullable: true),
                    CelularMadre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailMadre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DireccionMadre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FotoDniFrontalMadre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FotoDniDorsalMadre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MadreDeAtletas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PadreDeAtletas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAtleta = table.Column<int>(type: "int", nullable: false),
                    NombrePadre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ApellidoPadre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    DniPadre = table.Column<long>(type: "bigint", maxLength: 99999999, nullable: true),
                    CelularPadre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailPadre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DireccionPadre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FotoDniFrontalPadre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FotoDniDorsalPadre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PadreDeAtletas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TutorDeAtletas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAtleta = table.Column<int>(type: "int", nullable: false),
                    NombreTutor = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ApellidoTutor = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    DniTutor = table.Column<long>(type: "bigint", maxLength: 99999999, nullable: true),
                    CelularTutor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailTutor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DireccionTutor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FotoDniFrontalTutor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FotoDniDorsalTutor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TutorDeAtletas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Atletas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MadreAtletaId = table.Column<int>(type: "int", nullable: true),
                    PadreAtletaId = table.Column<int>(type: "int", nullable: true),
                    TutorAtletaId = table.Column<int>(type: "int", nullable: true),
                    NombreAtleta = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ApellidoAtleta = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Nacionalidad = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DniAtleta = table.Column<long>(type: "bigint", maxLength: 99999999, nullable: false),
                    NumeroDePasaporte = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    DireccionAtleta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAtleta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaDeNacimientoAtleta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CelularAtleta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Club = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    ObraSocialAtleta = table.Column<bool>(type: "bit", nullable: true),
                    NumeroCarnetObraSocial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PermisoDeViaje = table.Column<bool>(type: "bit", maxLength: 3, nullable: true),
                    Beca = table.Column<bool>(type: "bit", maxLength: 3, nullable: true),
                    FotoDniFrontalAtleta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FotoDniDorsalAtleta = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FotoPasaporteFrontalAtleta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FotoPasaporteDorsalAtleta = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atletas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Atletas_MadreDeAtletas_MadreAtletaId",
                        column: x => x.MadreAtletaId,
                        principalTable: "MadreDeAtletas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Atletas_PadreDeAtletas_PadreAtletaId",
                        column: x => x.PadreAtletaId,
                        principalTable: "PadreDeAtletas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Atletas_TutorDeAtletas_TutorAtletaId",
                        column: x => x.TutorAtletaId,
                        principalTable: "TutorDeAtletas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atletas_MadreAtletaId",
                table: "Atletas",
                column: "MadreAtletaId");

            migrationBuilder.CreateIndex(
                name: "IX_Atletas_PadreAtletaId",
                table: "Atletas",
                column: "PadreAtletaId");

            migrationBuilder.CreateIndex(
                name: "IX_Atletas_TutorAtletaId",
                table: "Atletas",
                column: "TutorAtletaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atletas");

            migrationBuilder.DropTable(
                name: "MadreDeAtletas");

            migrationBuilder.DropTable(
                name: "PadreDeAtletas");

            migrationBuilder.DropTable(
                name: "TutorDeAtletas");
        }
    }
}
