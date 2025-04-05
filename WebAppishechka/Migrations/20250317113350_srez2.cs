using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppishechka.Migrations
{
    /// <inheritdoc />
    public partial class srez2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MovieId",
                table: "ChatMessages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "ChatMessages");
        }
    }
}
