using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTA.Repository.Migrations
{
    public partial class BaseMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsertDate = table.Column<DateTime>(type: "datetime2(3)", precision: 3, nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2(3)", precision: 3, nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2(3)", precision: 3, nullable: true),
                    LastLoginDate = table.Column<DateTime>(type: "datetime2(3)", precision: 3, nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "ExpirationDate", "FirstName", "InsertDate", "IsEnabled", "LastLoginDate", "LastName", "ModifyDate", "Password", "Telephone", "Username" },
                values: new object[] { 1, "john.wick@example.com", null, "John", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Wick", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "123", "666555444", "tester" });

            migrationBuilder.CreateIndex(
                name: "UQ_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
