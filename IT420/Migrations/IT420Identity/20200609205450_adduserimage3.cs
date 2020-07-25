using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IT420.Migrations.IT420Identity
{
    public partial class adduserimage3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "userImg",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "userImg",
                table: "AspNetUsers",
                type: "tinyint",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldNullable: true);
        }
    }
}
