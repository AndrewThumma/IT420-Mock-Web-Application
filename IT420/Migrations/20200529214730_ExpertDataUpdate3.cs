using Microsoft.EntityFrameworkCore.Migrations;

namespace IT420.Migrations
{
    public partial class ExpertDataUpdate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpertQuestions_ExpertAnswers_answerId",
                table: "ExpertQuestions");

            migrationBuilder.DropIndex(
                name: "IX_ExpertQuestions_answerId",
                table: "ExpertQuestions");

            migrationBuilder.DropColumn(
                name: "answerId",
                table: "ExpertQuestions");

            migrationBuilder.AddColumn<int>(
                name: "questionId",
                table: "ExpertAnswers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ExpertAnswers_questionId",
                table: "ExpertAnswers",
                column: "questionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ExpertAnswers_ExpertQuestions_questionId",
                table: "ExpertAnswers",
                column: "questionId",
                principalTable: "ExpertQuestions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpertAnswers_ExpertQuestions_questionId",
                table: "ExpertAnswers");

            migrationBuilder.DropIndex(
                name: "IX_ExpertAnswers_questionId",
                table: "ExpertAnswers");

            migrationBuilder.DropColumn(
                name: "questionId",
                table: "ExpertAnswers");

            migrationBuilder.AddColumn<int>(
                name: "answerId",
                table: "ExpertQuestions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ExpertQuestions_answerId",
                table: "ExpertQuestions",
                column: "answerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ExpertQuestions_ExpertAnswers_answerId",
                table: "ExpertQuestions",
                column: "answerId",
                principalTable: "ExpertAnswers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
