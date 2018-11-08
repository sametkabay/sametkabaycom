using Microsoft.EntityFrameworkCore.Migrations;

namespace SametKabay.Core.Migrations
{
    public partial class InterfaceChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_ActivatingUserId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ActivatingUserId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ActivatingUserId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "ActivatedUserId",
                table: "BlogPosts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ActivatedUserId",
                table: "BlogComments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ActivatedUserId",
                table: "BlogCategories",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_ActivatedUserId",
                table: "BlogPosts",
                column: "ActivatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogComments_ActivatedUserId",
                table: "BlogComments",
                column: "ActivatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogCategories_ActivatedUserId",
                table: "BlogCategories",
                column: "ActivatedUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogCategories_Users_ActivatedUserId",
                table: "BlogCategories",
                column: "ActivatedUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogComments_Users_ActivatedUserId",
                table: "BlogComments",
                column: "ActivatedUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPosts_Users_ActivatedUserId",
                table: "BlogPosts",
                column: "ActivatedUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogCategories_Users_ActivatedUserId",
                table: "BlogCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogComments_Users_ActivatedUserId",
                table: "BlogComments");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogPosts_Users_ActivatedUserId",
                table: "BlogPosts");

            migrationBuilder.DropIndex(
                name: "IX_BlogPosts_ActivatedUserId",
                table: "BlogPosts");

            migrationBuilder.DropIndex(
                name: "IX_BlogComments_ActivatedUserId",
                table: "BlogComments");

            migrationBuilder.DropIndex(
                name: "IX_BlogCategories_ActivatedUserId",
                table: "BlogCategories");

            migrationBuilder.DropColumn(
                name: "ActivatedUserId",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "ActivatedUserId",
                table: "BlogComments");

            migrationBuilder.DropColumn(
                name: "ActivatedUserId",
                table: "BlogCategories");

            migrationBuilder.AddColumn<int>(
                name: "ActivatingUserId",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_ActivatingUserId",
                table: "Users",
                column: "ActivatingUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_ActivatingUserId",
                table: "Users",
                column: "ActivatingUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
