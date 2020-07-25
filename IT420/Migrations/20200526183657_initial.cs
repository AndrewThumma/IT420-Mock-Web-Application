using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IT420.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlogTypes",
                columns: table => new
                {
                    blogTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogTypes", x => x.blogTypeId);
                });

            migrationBuilder.CreateTable(
                name: "TalkTypes",
                columns: table => new
                {
                    TypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TalkTypes", x => x.TypeId);
                });

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    blogId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(maxLength: 100, nullable: false),
                    body = table.Column<string>(type: "text", nullable: false),
                    blogTypeId = table.Column<int>(nullable: false),
                    blogImageURL = table.Column<string>(nullable: true),
                    approved = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    userId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.blogId);
                    table.ForeignKey(
                        name: "FK_Blogs_BlogTypes_blogTypeId",
                        column: x => x.blogTypeId,
                        principalTable: "BlogTypes",
                        principalColumn: "blogTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Talks",
                columns: table => new
                {
                    TalkId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Body = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    userId = table.Column<int>(nullable: false),
                    TalkTypeTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Talks", x => x.TalkId);
                    table.ForeignKey(
                        name: "FK_Talks_TalkTypes_TalkTypeTypeId",
                        column: x => x.TalkTypeTypeId,
                        principalTable: "TalkTypes",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TalkComments",
                columns: table => new
                {
                    CommentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TalkId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    userId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TalkComments", x => x.CommentID);
                    table.ForeignKey(
                        name: "FK_TalkComments_Talks_TalkId",
                        column: x => x.TalkId,
                        principalTable: "Talks",
                        principalColumn: "TalkId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_blogTypeId",
                table: "Blogs",
                column: "blogTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TalkComments_TalkId",
                table: "TalkComments",
                column: "TalkId");

            migrationBuilder.CreateIndex(
                name: "IX_Talks_TalkTypeTypeId",
                table: "Talks",
                column: "TalkTypeTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "TalkComments");

            migrationBuilder.DropTable(
                name: "BlogTypes");

            migrationBuilder.DropTable(
                name: "Talks");

            migrationBuilder.DropTable(
                name: "TalkTypes");
        }
    }
}
