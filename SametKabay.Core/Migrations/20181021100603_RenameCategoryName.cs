using Microsoft.EntityFrameworkCore.Migrations;

namespace SametKabay.Core.Migrations
{
    public partial class RenameCategoryName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "BlogCategories",
                newName: "SafeName");

            migrationBuilder.RenameColumn(
                name: "SafeTitle",
                table: "BlogCategories",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SafeName",
                table: "BlogCategories",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "BlogCategories",
                newName: "SafeTitle");
        }
    }
}
