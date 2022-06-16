using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace V1.Migrations
{
    public partial class InitialRoleSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6d7db6be-65ee-442a-a795-b078d71c7e8b", "af016ff5-07c5-4b6e-88ec-318a9c10042d", "Manager", "MANAGER" },
                    { "87463c5a-795c-4df2-83a5-ef985f76c0d5", "a149d497-ca84-497a-a284-45ca624f2ab6", "Client", "CLIENT" },
                    { "ab662ea0-b950-4c0a-b9e1-cafd808bdd45", "d632246b-2571-4adb-be5c-1db2f6c754b8", "Administrator", "ADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d7db6be-65ee-442a-a795-b078d71c7e8b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87463c5a-795c-4df2-83a5-ef985f76c0d5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ab662ea0-b950-4c0a-b9e1-cafd808bdd45");
        }
    }
}
