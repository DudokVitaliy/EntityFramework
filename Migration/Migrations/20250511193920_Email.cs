using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MigrationComp.Migrations
{
    /// <inheritdoc />
    using Microsoft.EntityFrameworkCore.Migrations;
    public partial class Email : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Workers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Email",
                value: "noemail");

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Email",
                value: "noemail");

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 3,
                column: "Email",
                value: "noemail");

            migrationBuilder.UpdateData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 4,
                column: "Email",
                value: "noemail");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Workers");
        }
    }
}
