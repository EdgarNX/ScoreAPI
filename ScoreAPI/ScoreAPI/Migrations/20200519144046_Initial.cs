using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ScoreAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Scores",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(nullable: false),
                    Points = table.Column<int>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scores", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Scores",
                columns: new[] { "Id", "Points", "UserName" },
                values: new object[,]
                {
                    { new Guid("6b1eea43-5597-45a6-bdea-e68c60564247"), 12, "Edgar" },
                    { new Guid("a052a63d-fa53-44d5-a197-83089818a676"), 31, "Ianko" },
                    { new Guid("cb554ed6-8fa7-4b8d-8d90-55cc6a3e0074"), 63, "Fernando" },
                    { new Guid("8e2f0a16-4c09-44c7-ba56-8dc62dfd792d"), 99, "Paul" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Scores");
        }
    }
}
