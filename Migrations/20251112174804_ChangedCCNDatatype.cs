using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INETAssignment1.Migrations
{
    /// <inheritdoc />
    public partial class ChangedCCNDatatype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "creditCardNumber",
                table: "Purchase",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "creditCardNumber",
                table: "Purchase",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
