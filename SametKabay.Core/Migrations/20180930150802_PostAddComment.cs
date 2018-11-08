using Microsoft.EntityFrameworkCore.Migrations;

namespace SametKabay.Core.Migrations
{
    public partial class PostAddComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BlogPostId",
                table: "BlogComments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BlogComments_BlogPostId",
                table: "BlogComments",
                column: "BlogPostId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogComments_BlogPosts_BlogPostId",
                table: "BlogComments",
                column: "BlogPostId",
                principalTable: "BlogPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogComments_BlogPosts_BlogPostId",
                table: "BlogComments");

            migrationBuilder.DropIndex(
                name: "IX_BlogComments_BlogPostId",
                table: "BlogComments");

            migrationBuilder.DropColumn(
                name: "BlogPostId",
                table: "BlogComments");
        }
    }
}
