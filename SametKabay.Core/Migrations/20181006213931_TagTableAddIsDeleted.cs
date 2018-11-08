using Microsoft.EntityFrameworkCore.Migrations;

namespace SametKabay.Core.Migrations
{
    public partial class TagTableAddIsDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "BlogPostTags",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "BlogCategoryTags",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "BlogPostTags");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "BlogCategoryTags");
        }
    }
}
