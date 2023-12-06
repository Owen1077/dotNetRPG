using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnet_rpg.Migrations
{
    public partial class seedSkills : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Damage",
                table: "Skills",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Damage", "Name" },
                values: new object[] { 1, 30, "Fireball" });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Damage", "Name" },
                values: new object[] { 2, 20, "Frenzy" });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Damage", "Name" },
                values: new object[] { 3, 40, "Blizzard" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<string>(
                name: "Damage",
                table: "Skills",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
