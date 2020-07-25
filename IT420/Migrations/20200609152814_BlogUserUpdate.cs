using Microsoft.EntityFrameworkCore.Migrations;

namespace IT420.Migrations
{
    public partial class BlogUserUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "userId",
                table: "Blogs",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "userProfileId",
                table: "Blogs",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "userId",
                table: "Blogs",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
