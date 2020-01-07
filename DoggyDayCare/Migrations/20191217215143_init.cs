using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DoggyDayCare.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "DoggyDayCare");

            migrationBuilder.CreateTable(
                name: "Students",
                schema: "DoggyDayCare",
                columns: table => new
                {
                    StudentId = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "Dog",
                schema: "DoggyDayCare",
                columns: table => new
                {
                    DogId = table.Column<string>(nullable: false),
                    OwnerId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Breed = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dog", x => x.DogId);
                    table.ForeignKey(
                        name: "FK_Dog_Students_OwnerId",
                        column: x => x.OwnerId,
                        principalSchema: "DoggyDayCare",
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TimeSheets",
                schema: "DoggyDayCare",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTimeOffset>(nullable: false),
                    TimeIn = table.Column<DateTimeOffset>(nullable: false),
                    TimeOut = table.Column<DateTimeOffset>(nullable: false),
                    TotalCharged = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    TotalPaid = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    DogId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSheets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeSheets_Dog_DogId",
                        column: x => x.DogId,
                        principalSchema: "DoggyDayCare",
                        principalTable: "Dog",
                        principalColumn: "DogId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dog_OwnerId",
                schema: "DoggyDayCare",
                table: "Dog",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSheets_DogId",
                schema: "DoggyDayCare",
                table: "TimeSheets",
                column: "DogId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeSheets",
                schema: "DoggyDayCare");

            migrationBuilder.DropTable(
                name: "Dog",
                schema: "DoggyDayCare");

            migrationBuilder.DropTable(
                name: "Students",
                schema: "DoggyDayCare");
        }
    }
}
