using Microsoft.EntityFrameworkCore.Migrations;

namespace SametKabay.Core.Migrations
{
    public partial class ModifiedSafeTitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SafeTittle",
                table: "BlogPosts",
                newName: "SafeTitle");

            migrationBuilder.RenameColumn(
                name: "SafeTittle",
                table: "BlogCategories",
                newName: "SafeTitle");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SafeTitle",
                table: "BlogPosts",
                newName: "SafeTittle");

            migrationBuilder.RenameColumn(
                name: "SafeTitle",
                table: "BlogCategories",
                newName: "SafeTittle");
        }
    }
}
