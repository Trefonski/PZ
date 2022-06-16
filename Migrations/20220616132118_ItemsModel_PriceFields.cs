using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace V1.Migrations
{
    public partial class ItemsModel_PriceFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Discount",
                table: "Items",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "NettPrice",
                table: "Items",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "VAT",
                table: "Items",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "NettPrice",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "VAT",
                table: "Items");
        }
    }
}
