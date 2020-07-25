using Microsoft.EntityFrameworkCore.Migrations;

namespace IT420.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BlogTypes",
                columns: new[] { "blogTypeId", "type" },
                values: new object[,]
                {
                    { 1, "Breastfeeding" },
                    { 2, "Eduction and Learning" },
                    { 3, "Hobbies" }
                });

            migrationBuilder.InsertData(
                table: "ExpertQuestionTypes",
                columns: new[] { "id", "type" },
                values: new object[,]
                {
                    { 1, "Health Corner" },
                    { 2, "Nutrition Corner" }
                });

            migrationBuilder.InsertData(
                table: "TalkTypes",
                columns: new[] { "TypeId", "Type" },
                values: new object[,]
                {
                    { 1, "Parenting" },
                    { 2, "Career" },
                    { 3, "Babycare" },
                    { 4, "Food and Nutrition" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BlogTypes",
                keyColumn: "blogTypeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BlogTypes",
                keyColumn: "blogTypeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BlogTypes",
                keyColumn: "blogTypeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ExpertQuestionTypes",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ExpertQuestionTypes",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TalkTypes",
                keyColumn: "TypeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TalkTypes",
                keyColumn: "TypeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TalkTypes",
                keyColumn: "TypeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TalkTypes",
                keyColumn: "TypeId",
                keyValue: 4);
        }
    }
}
