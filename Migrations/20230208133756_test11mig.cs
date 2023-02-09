using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogWebSite.Migrations
{
    /// <inheritdoc />
    public partial class test11mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserPicture",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PostImage",
                table: "BlogEntries",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserPicture",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PostImage",
                table: "BlogEntries");
        }
    }
}
