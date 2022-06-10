using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace V1.Migrations
{
    public partial class ver2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDates_Status",
                table: "OrderDates");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropIndex(
                name: "IX_OrderDates_ID_Status",
                table: "OrderDates");

            migrationBuilder.DropColumn(
                name: "ID_Status",
                table: "OrderDates");

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Reviews",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "OrderDates",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Sex",
                table: "Items",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Clients_Login",
                table: "Clients",
                column: "Login");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserName",
                table: "AspNetUsers",
                column: "UserName",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Clients_UserName",
                table: "AspNetUsers",
                column: "UserName",
                principalTable: "Clients",
                principalColumn: "Login",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Clients_UserName",
                table: "AspNetUsers");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Clients_Login",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UserName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "OrderDates");

            migrationBuilder.DropColumn(
                name: "Sex",
                table: "Items");

            migrationBuilder.AddColumn<byte>(
                name: "ID_Status",
                table: "OrderDates",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    ID_Status = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.ID_Status);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDates_ID_Status",
                table: "OrderDates",
                column: "ID_Status");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDates_Status",
                table: "OrderDates",
                column: "ID_Status",
                principalTable: "Status",
                principalColumn: "ID_Status",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
