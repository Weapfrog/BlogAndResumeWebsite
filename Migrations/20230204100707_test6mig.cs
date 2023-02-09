using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogWebSite.Migrations
{
    /// <inheritdoc />
    public partial class test6mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Keywords",
                table: "BlogEntries");

            migrationBuilder.AddColumn<string>(
                name: "eMail",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "eMail",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Keywords",
                table: "BlogEntries",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
