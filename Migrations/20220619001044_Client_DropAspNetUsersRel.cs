using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace V1.Migrations
{
    public partial class Client_DropAspNetUsersRel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
