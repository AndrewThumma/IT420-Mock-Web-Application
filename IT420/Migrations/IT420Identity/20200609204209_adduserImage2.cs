using Microsoft.EntityFrameworkCore.Migrations;

namespace IT420.Migrations.IT420Identity
{
    public partial class adduserImage2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "userImg",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "userImg",
                table: "AspNetUsers",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(byte),
                oldNullable: true);
        }
    }
}
