using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MigrationComp.Migrations
{
    /// <inheritdoc />
    using Microsoft.EntityFrameworkCore.Migrations;
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "char(50)", unicode: false, fixedLength: true, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LaunchDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workers_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Workers_Position_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Position",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectWorker",
                columns: table => new
                {
                    ProjectsId = table.Column<int>(type: "int", nullable: false),
                    WorkersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectWorker", x => new { x.ProjectsId, x.WorkersId });
                    table.ForeignKey(
                        name: "FK_ProjectWorker_Projects_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectWorker_Workers_WorkersId",
                        column: x => x.WorkersId,
                        principalTable: "Workers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Ukraine" },
                    { 2, "Poland" },
                    { 3, "USA" }
                });

            migrationBuilder.InsertData(
                table: "Position",
                columns: new[] { "Id", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "Managment", "45-85-96" },
                    { 2, "Programing", "45-85-05" },
                    { 3, "Design", "45-79-35" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "LaunchDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(1992, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tetris" },
                    { 2, new DateTime(2000, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "CS" },
                    { 3, new DateTime(1999, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "PacMan" }
                });

            migrationBuilder.InsertData(
                table: "Workers",
                columns: new[] { "Id", "Birthday", "CountryId", "DepartmentID", "Name", "Salary", "Surname" },
                values: new object[,]
                {
                    { 1, new DateTime(2003, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "Bill", 2700, "Gates" },
                    { 2, new DateTime(2002, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, "Tomm", 4300, "Page" },
                    { 3, new DateTime(2000, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, "Emma", 5500, "Miller" },
                    { 4, new DateTime(2003, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3, "Oleg", 3300, "King" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectWorker_WorkersId",
                table: "ProjectWorker",
                column: "WorkersId");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_CountryId",
                table: "Workers",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_DepartmentID",
                table: "Workers",
                column: "DepartmentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectWorker");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Workers");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Position");
        }
    }
}
