using Microsoft.EntityFrameworkCore.Migrations;

namespace IT420.Migrations
{
    public partial class ExpertDataUpdate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "bio",
                table: "Experts",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bio",
                table: "Experts");
        }
    }
}
