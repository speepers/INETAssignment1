using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INETAssignment1.Migrations
{
    /// <inheritdoc />
    public partial class IntialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    genreID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    genreName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    genreDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.genreID);
                });

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
                    genreID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Band", x => x.bandID);
                    table.ForeignKey(
                        name: "FK_Band_Genre_genreID",
                        column: x => x.genreID,
                        principalTable: "Genre",
                        principalColumn: "genreID");
                });

            migrationBuilder.CreateTable(
                name: "Concert",
                columns: table => new
                {
                    concertID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    concertName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tourName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bandID = table.Column<int>(type: "int", nullable: true),
                    locationID = table.Column<int>(type: "int", nullable: true),
                    concertTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concert", x => x.concertID);
                    table.ForeignKey(
                        name: "FK_Concert_Band_bandID",
                        column: x => x.bandID,
                        principalTable: "Band",
                        principalColumn: "bandID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Concert_Location_locationID",
                        column: x => x.locationID,
                        principalTable: "Location",
                        principalColumn: "locationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConcertGenre",
                columns: table => new
                {
                    GenresgenreID = table.Column<int>(type: "int", nullable: false),
                    concertsconcertID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConcertGenre", x => new { x.GenresgenreID, x.concertsconcertID });
                    table.ForeignKey(
                        name: "FK_ConcertGenre_Concert_concertsconcertID",
                        column: x => x.concertsconcertID,
                        principalTable: "Concert",
                        principalColumn: "concertID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConcertGenre_Genre_GenresgenreID",
                        column: x => x.GenresgenreID,
                        principalTable: "Genre",
                        principalColumn: "genreID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Band_genreID",
                table: "Band",
                column: "genreID");

            migrationBuilder.CreateIndex(
                name: "IX_Concert_bandID",
                table: "Concert",
                column: "bandID");

            migrationBuilder.CreateIndex(
                name: "IX_Concert_locationID",
                table: "Concert",
                column: "locationID");

            migrationBuilder.CreateIndex(
                name: "IX_ConcertGenre_concertsconcertID",
                table: "ConcertGenre",
                column: "concertsconcertID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConcertGenre");

            migrationBuilder.DropTable(
                name: "Concert");

            migrationBuilder.DropTable(
                name: "Band");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Genre");
        }
    }
}
