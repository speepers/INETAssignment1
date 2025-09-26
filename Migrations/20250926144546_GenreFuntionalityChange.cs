using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INETAssignment1.Migrations
{
    /// <inheritdoc />
    public partial class GenreFuntionalityChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genre_Band_bandID",
                table: "Genre");

            migrationBuilder.DropIndex(
                name: "IX_Genre_bandID",
                table: "Genre");

            migrationBuilder.DropColumn(
                name: "bandID",
                table: "Genre");

            migrationBuilder.AddColumn<int>(
                name: "genreID",
                table: "Band",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Band_genreID",
                table: "Band",
                column: "genreID");

            migrationBuilder.AddForeignKey(
                name: "FK_Band_Genre_genreID",
                table: "Band",
                column: "genreID",
                principalTable: "Genre",
                principalColumn: "genreID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Band_Genre_genreID",
                table: "Band");

            migrationBuilder.DropIndex(
                name: "IX_Band_genreID",
                table: "Band");

            migrationBuilder.DropColumn(
                name: "genreID",
                table: "Band");

            migrationBuilder.AddColumn<int>(
                name: "bandID",
                table: "Genre",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Genre_bandID",
                table: "Genre",
                column: "bandID");

            migrationBuilder.AddForeignKey(
                name: "FK_Genre_Band_bandID",
                table: "Genre",
                column: "bandID",
                principalTable: "Band",
                principalColumn: "bandID");
        }
    }
}
