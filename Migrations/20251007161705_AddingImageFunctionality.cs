using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INETAssignment1.Migrations
{
    /// <inheritdoc />
    public partial class AddingImageFunctionality : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "filename",
                table: "Concert",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "filename",
                table: "Concert");
        }
    }
}
