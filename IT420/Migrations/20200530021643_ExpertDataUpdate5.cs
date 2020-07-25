using Microsoft.EntityFrameworkCore.Migrations;

namespace IT420.Migrations
{
    public partial class ExpertDataUpdate5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "ExpertQuestions",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "userId",
                table: "ExpertQuestions");
        }
    }
}
