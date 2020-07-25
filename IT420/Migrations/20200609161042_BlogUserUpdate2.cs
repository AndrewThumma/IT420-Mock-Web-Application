using Microsoft.EntityFrameworkCore.Migrations;

namespace IT420.Migrations
{
    public partial class BlogUserUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_UserProfile_userProfileId",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_userProfileId",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "userProfileId",
                table: "Blogs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "userProfileId",
                table: "Blogs",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_userProfileId",
                table: "Blogs",
                column: "userProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_UserProfile_userProfileId",
                table: "Blogs",
                column: "userProfileId",
                principalTable: "UserProfile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
