﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspnetserver.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Content = table.Column<string>(type: "TEXT", maxLength: 10000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostID);
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostID", "Content", "Title" },
                values: new object[] { 1, "This is post 1 has some very interesting content.", "Post 1" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostID", "Content", "Title" },
                values: new object[] { 2, "This is post 2 has some very interesting content.", "Post 2" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostID", "Content", "Title" },
                values: new object[] { 3, "This is post 3 has some very interesting content.", "Post 3" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostID", "Content", "Title" },
                values: new object[] { 4, "This is post 4 has some very interesting content.", "Post 4" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostID", "Content", "Title" },
                values: new object[] { 5, "This is post 5 has some very interesting content.", "Post 5" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostID", "Content", "Title" },
                values: new object[] { 6, "This is post 6 has some very interesting content.", "Post 6" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
