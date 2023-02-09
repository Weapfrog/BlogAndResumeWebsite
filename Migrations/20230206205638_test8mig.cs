using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogWebSite.Migrations
{
    /// <inheritdoc />
    public partial class test8mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Dislikes",
                table: "BlogEntries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "BlogEntries",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dislikes",
                table: "BlogEntries");

            migrationBuilder.DropColumn(
                name: "Likes",
                table: "BlogEntries");
        }
    }
}
