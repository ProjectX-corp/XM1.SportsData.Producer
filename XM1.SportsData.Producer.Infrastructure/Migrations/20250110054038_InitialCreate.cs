using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XM1.SportsData.Producer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "XM1_TB0005_PAISES",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Nome = table.Column<string>(type: "longtext", nullable: false),
                    LogoUrl = table.Column<string>(type: "longtext", nullable: false),
                    IdApi = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XM1_TB0005_PAISES", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "XM1_TB0006_LIGAS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Nome = table.Column<string>(type: "longtext", nullable: false),
                    LogoUrl = table.Column<string>(type: "longtext", nullable: false),
                    PaisId = table.Column<Guid>(type: "char(36)", nullable: false),
                    IdApi = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XM1_TB0006_LIGAS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_XM1_TB0006_LIGAS_XM1_TB0005_PAISES_PaisId",
                        column: x => x.PaisId,
                        principalTable: "XM1_TB0005_PAISES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "XM1_TB0007_TIMES",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Nome = table.Column<string>(type: "longtext", nullable: false),
                    LogoUrl = table.Column<string>(type: "longtext", nullable: false),
                    LigaId = table.Column<Guid>(type: "char(36)", nullable: false),
                    IdApi = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XM1_TB0007_TIMES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_XM1_TB0007_TIMES_XM1_TB0006_LIGAS_LigaId",
                        column: x => x.LigaId,
                        principalTable: "XM1_TB0006_LIGAS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "XM1_TB0008_PARTIDAS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    TimeCasaId = table.Column<Guid>(type: "char(36)", nullable: false),
                    TimeVisitanteId = table.Column<Guid>(type: "char(36)", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Rodada = table.Column<int>(type: "int", nullable: false),
                    GolsTimeCasa = table.Column<int>(type: "int", nullable: true),
                    GolsTimeVisitante = table.Column<int>(type: "int", nullable: true),
                    IsResultadoCompleto = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IdApi = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XM1_TB0008_PARTIDAS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_XM1_TB0008_PARTIDAS_XM1_TB0007_TIMES_TimeCasaId",
                        column: x => x.TimeCasaId,
                        principalTable: "XM1_TB0007_TIMES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_XM1_TB0008_PARTIDAS_XM1_TB0007_TIMES_TimeVisitanteId",
                        column: x => x.TimeVisitanteId,
                        principalTable: "XM1_TB0007_TIMES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_XM1_TB0006_LIGAS_PaisId",
                table: "XM1_TB0006_LIGAS",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_XM1_TB0007_TIMES_LigaId",
                table: "XM1_TB0007_TIMES",
                column: "LigaId");

            migrationBuilder.CreateIndex(
                name: "IX_XM1_TB0008_PARTIDAS_TimeCasaId",
                table: "XM1_TB0008_PARTIDAS",
                column: "TimeCasaId");

            migrationBuilder.CreateIndex(
                name: "IX_XM1_TB0008_PARTIDAS_TimeVisitanteId",
                table: "XM1_TB0008_PARTIDAS",
                column: "TimeVisitanteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "XM1_TB0008_PARTIDAS");

            migrationBuilder.DropTable(
                name: "XM1_TB0007_TIMES");

            migrationBuilder.DropTable(
                name: "XM1_TB0006_LIGAS");

            migrationBuilder.DropTable(
                name: "XM1_TB0005_PAISES");
        }
    }
}
