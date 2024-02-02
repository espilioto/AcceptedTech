using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace acceptedTech.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedSpecifierColumnType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Specifier",
                table: "MatchOdds",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Specifier",
                table: "MatchOdds",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
