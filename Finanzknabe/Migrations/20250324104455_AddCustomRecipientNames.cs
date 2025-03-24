using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finanzknabe.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomRecipientNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomName",
                table: "Recipients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomName",
                table: "Recipients");
        }
    }
}
