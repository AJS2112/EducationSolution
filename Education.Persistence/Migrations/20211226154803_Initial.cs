using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Education.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Curses",
                columns: table => new
                {
                    CurseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curses", x => x.CurseId);
                });

            migrationBuilder.InsertData(
                table: "Curses",
                columns: new[] { "CurseId", "CreationDate", "Description", "Price", "PublishDate", "Title" },
                values: new object[] { new Guid("58f5732e-c3f7-4a81-b856-dc6256164287"), new DateTime(2021, 12, 26, 15, 48, 2, 577, DateTimeKind.Utc).AddTicks(4954), "C# basic curse", 60m, new DateTime(2023, 12, 26, 15, 48, 2, 577, DateTimeKind.Utc).AddTicks(5275), "C# From Zero to Hero" });

            migrationBuilder.InsertData(
                table: "Curses",
                columns: new[] { "CurseId", "CreationDate", "Description", "Price", "PublishDate", "Title" },
                values: new object[] { new Guid("a0ab84df-9234-46fa-b73d-ea914c7157ec"), new DateTime(2021, 12, 26, 15, 48, 2, 578, DateTimeKind.Utc).AddTicks(6233), "Java Curse", 40m, new DateTime(2023, 12, 26, 15, 48, 2, 578, DateTimeKind.Utc).AddTicks(6234), "Mastery Java" });

            migrationBuilder.InsertData(
                table: "Curses",
                columns: new[] { "CurseId", "CreationDate", "Description", "Price", "PublishDate", "Title" },
                values: new object[] { new Guid("2ce1fd43-2fa5-48fd-9928-2b64a7438f37"), new DateTime(2021, 12, 26, 15, 48, 2, 578, DateTimeKind.Utc).AddTicks(6324), "Unit Test For Net Core", 100m, new DateTime(2023, 12, 26, 15, 48, 2, 578, DateTimeKind.Utc).AddTicks(6325), "NetCore Unit Testing" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Curses");
        }
    }
}
