using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IT420.Migrations
{
    public partial class AddExpertImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imageURL",
                table: "Experts");

            migrationBuilder.AddColumn<byte[]>(
                name: "userImg",
                table: "UserProfile",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "image",
                table: "Experts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "userImg",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "image",
                table: "Experts");

            migrationBuilder.AddColumn<string>(
                name: "imageURL",
                table: "Experts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
