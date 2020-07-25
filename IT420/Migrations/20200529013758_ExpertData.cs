using Microsoft.EntityFrameworkCore.Migrations;

namespace IT420.Migrations
{
    public partial class ExpertData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExpertQuestionTypes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpertQuestionTypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Experts",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(maxLength: 100, nullable: false),
                    lastName = table.Column<string>(maxLength: 100, nullable: false),
                    specialty = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ExpertAnswers",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    answer = table.Column<string>(nullable: false),
                    expertId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpertAnswers", x => x.id);
                    table.ForeignKey(
                        name: "FK_ExpertAnswers_Experts_expertId",
                        column: x => x.expertId,
                        principalTable: "Experts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExpertQuestions",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    question = table.Column<string>(nullable: false),
                    typeId = table.Column<int>(nullable: false),
                    answerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpertQuestions", x => x.id);
                    table.ForeignKey(
                        name: "FK_ExpertQuestions_ExpertAnswers_answerId",
                        column: x => x.answerId,
                        principalTable: "ExpertAnswers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExpertQuestions_ExpertQuestionTypes_typeId",
                        column: x => x.typeId,
                        principalTable: "ExpertQuestionTypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExpertAnswers_expertId",
                table: "ExpertAnswers",
                column: "expertId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpertQuestions_answerId",
                table: "ExpertQuestions",
                column: "answerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExpertQuestions_typeId",
                table: "ExpertQuestions",
                column: "typeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExpertQuestions");

            migrationBuilder.DropTable(
                name: "ExpertAnswers");

            migrationBuilder.DropTable(
                name: "ExpertQuestionTypes");

            migrationBuilder.DropTable(
                name: "Experts");
        }
    }
}
