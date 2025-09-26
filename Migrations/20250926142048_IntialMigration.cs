using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INETAssignment1.Migrations
{
    /// <inheritdoc />
    public partial class IntialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    locationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    locationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    locationDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.locationID);
                });

            migrationBuilder.CreateTable(
                name: "Band",
                columns: table => new
                {
                    bandID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bandName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bandDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    concertID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Band", x => x.bandID);
                });

            migrationBuilder.CreateTable(
                name: "Concert",
                columns: table => new
                {
                    concertID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    concertName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tourName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    headliningBandbandID = table.Column<int>(type: "int", nullable: true),
                    concertLocationlocationID = table.Column<int>(type: "int", nullable: true),
                    concertTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concert", x => x.concertID);
                    table.ForeignKey(
                        name: "FK_Concert_Band_headliningBandbandID",
                        column: x => x.headliningBandbandID,
                        principalTable: "Band",
                        principalColumn: "bandID");
                    table.ForeignKey(
                        name: "FK_Concert_Location_concertLocationlocationID",
                        column: x => x.concertLocationlocationID,
                        principalTable: "Location",
                        principalColumn: "locationID");
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    genreID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    genreName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    genreDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bandID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.genreID);
                    table.ForeignKey(
                        name: "FK_Genre_Band_bandID",
                        column: x => x.bandID,
                        principalTable: "Band",
                        principalColumn: "bandID");
                });

            migrationBuilder.CreateTable(
                name: "ConcertGenre",
                columns: table => new
                {
                    concertGenresgenreID = table.Column<int>(type: "int", nullable: false),
                    concertsconcertID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConcertGenre", x => new { x.concertGenresgenreID, x.concertsconcertID });
                    table.ForeignKey(
                        name: "FK_ConcertGenre_Concert_concertsconcertID",
                        column: x => x.concertsconcertID,
                        principalTable: "Concert",
                        principalColumn: "concertID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConcertGenre_Genre_concertGenresgenreID",
                        column: x => x.concertGenresgenreID,
                        principalTable: "Genre",
                        principalColumn: "genreID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Band_concertID",
                table: "Band",
                column: "concertID");

            migrationBuilder.CreateIndex(
                name: "IX_Concert_concertLocationlocationID",
                table: "Concert",
                column: "concertLocationlocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Concert_headliningBandbandID",
                table: "Concert",
                column: "headliningBandbandID");

            migrationBuilder.CreateIndex(
                name: "IX_ConcertGenre_concertsconcertID",
                table: "ConcertGenre",
                column: "concertsconcertID");

            migrationBuilder.CreateIndex(
                name: "IX_Genre_bandID",
                table: "Genre",
                column: "bandID");

            migrationBuilder.AddForeignKey(
                name: "FK_Band_Concert_concertID",
                table: "Band",
                column: "concertID",
                principalTable: "Concert",
                principalColumn: "concertID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Band_Concert_concertID",
                table: "Band");

            migrationBuilder.DropTable(
                name: "ConcertGenre");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Concert");

            migrationBuilder.DropTable(
                name: "Band");

            migrationBuilder.DropTable(
                name: "Location");
        }
    }
}
