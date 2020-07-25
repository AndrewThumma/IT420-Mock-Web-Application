using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IT420.Migrations.IT420Identity
{
    public partial class IdentityUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Expert_Expertid",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ExpertQuestionAnswer");

            migrationBuilder.DropTable(
                name: "Expert");

            migrationBuilder.DropTable(
                name: "ExpertQuestion");

            migrationBuilder.DropTable(
                name: "ExpertQuestionType");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Expertid",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Expertid",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Expertid",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Expert",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bio = table.Column<string>(type: "text", nullable: false),
                    firstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    imageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    specialty = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expert", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ExpertQuestionType",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpertQuestionType", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ExpertQuestion",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    answered = table.Column<bool>(type: "bit", nullable: false),
                    question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    typeId = table.Column<int>(type: "int", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpertQuestion", x => x.id);
                    table.ForeignKey(
                        name: "FK_ExpertQuestion_ExpertQuestionType_typeId",
                        column: x => x.typeId,
                        principalTable: "ExpertQuestionType",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExpertQuestionAnswer",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    expertId = table.Column<int>(type: "int", nullable: false),
                    questionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpertQuestionAnswer", x => x.id);
                    table.ForeignKey(
                        name: "FK_ExpertQuestionAnswer_Expert_expertId",
                        column: x => x.expertId,
                        principalTable: "Expert",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExpertQuestionAnswer_ExpertQuestion_questionId",
                        column: x => x.questionId,
                        principalTable: "ExpertQuestion",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Expertid",
                table: "AspNetUsers",
                column: "Expertid");

            migrationBuilder.CreateIndex(
                name: "IX_ExpertQuestion_typeId",
                table: "ExpertQuestion",
                column: "typeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpertQuestionAnswer_expertId",
                table: "ExpertQuestionAnswer",
                column: "expertId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpertQuestionAnswer_questionId",
                table: "ExpertQuestionAnswer",
                column: "questionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Expert_Expertid",
                table: "AspNetUsers",
                column: "Expertid",
                principalTable: "Expert",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
