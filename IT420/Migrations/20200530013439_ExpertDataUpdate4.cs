using Microsoft.EntityFrameworkCore.Migrations;

namespace IT420.Migrations
{
    public partial class ExpertDataUpdate4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "answered",
                table: "ExpertQuestions",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "answered",
                table: "ExpertQuestions");
        }
    }
}
