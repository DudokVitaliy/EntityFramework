using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MigrationComp.Migrations
{
    /// <inheritdoc />
    using Microsoft.EntityFrameworkCore.Migrations;
    public partial class NullCountry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Countries_CountryId",
                table: "Workers");

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "Workers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Countries_CountryId",
                table: "Workers",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Countries_CountryId",
                table: "Workers");

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "Workers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Countries_CountryId",
                table: "Workers",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
