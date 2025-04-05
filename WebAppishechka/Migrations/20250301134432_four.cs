using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppishechka.Migrations
{
    /// <inheritdoc />
    public partial class four : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "UserChat");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "UserChat",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
