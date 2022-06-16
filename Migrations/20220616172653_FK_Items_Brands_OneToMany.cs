using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace V1.Migrations
{
    public partial class FK_Items_Brands_OneToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Items_ID_Brand",
                table: "Items");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ID_Brand",
                table: "Items",
                column: "ID_Brand");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Items_ID_Brand",
                table: "Items");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ID_Brand",
                table: "Items",
                column: "ID_Brand",
                unique: true);
        }
    }
}
