using Microsoft.EntityFrameworkCore.Migrations;

namespace IT420.Migrations.IT420Identity
{
    public partial class addUserImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "userImg",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "userImg",
                table: "AspNetUsers");
        }
    }
}
