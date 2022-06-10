using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace V1.Migrations
{
    public partial class ver1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    ID_Brand = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BrandName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.ID_Brand);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ID_Client = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Login = table.Column<string>(type: "text", nullable: false),
                    ClientName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ID_Client);
                });

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

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ID_Item = table.Column<string>(type: "text", nullable: false),
                    ID_Brand = table.Column<long>(type: "bigint", nullable: false),
                    Size = table.Column<float>(type: "real", nullable: false),
                    Colour = table.Column<string>(type: "text", nullable: false),
                    Style = table.Column<string>(type: "text", nullable: false),
                    Stock = table.Column<long>(type: "bigint", nullable: false),
                    ItemName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ID_Item);
                    table.ForeignKey(
                        name: "FK_Items_Brands",
                        column: x => x.ID_Brand,
                        principalTable: "Brands",
                        principalColumn: "ID_Brand",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    ID_Address = table.Column<byte>(type: "smallint", nullable: false),
                    ID_Client = table.Column<long>(type: "bigint", nullable: false),
                    Default = table.Column<bool>(type: "boolean", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    Voivodeship = table.Column<string>(type: "text", nullable: false),
                    County = table.Column<string>(type: "text", nullable: false),
                    PostCode = table.Column<string>(type: "text", nullable: false),
                    Street = table.Column<string>(type: "text", nullable: false),
                    BlockNo = table.Column<int>(type: "integer", nullable: false),
                    HouseNo = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => new { x.ID_Address, x.ID_Client });
                    table.ForeignKey(
                        name: "FK_Addresses_Clients",
                        column: x => x.ID_Client,
                        principalTable: "Clients",
                        principalColumn: "ID_Client",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    ID_Order = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ID_Client = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.ID_Order);
                    table.ForeignKey(
                        name: "FK_Orders_Clients",
                        column: x => x.ID_Client,
                        principalTable: "Clients",
                        principalColumn: "ID_Client",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pictures",
                columns: table => new
                {
                    ID_Picture = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ID_Item = table.Column<string>(type: "text", nullable: false),
                    Picture = table.Column<byte[]>(type: "bytea", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pictures", x => x.ID_Picture);
                    table.ForeignKey(
                        name: "FK_Pictures_Items",
                        column: x => x.ID_Item,
                        principalTable: "Items",
                        principalColumn: "ID_Item",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ID_Client = table.Column<long>(type: "bigint", nullable: false),
                    ID_Item = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Body = table.Column<string>(type: "text", nullable: false),
                    DatePosted = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => new { x.ID_Client, x.ID_Item });
                    table.ForeignKey(
                        name: "FK_Reviews_Clients",
                        column: x => x.ID_Client,
                        principalTable: "Clients",
                        principalColumn: "ID_Client",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reviews_Items",
                        column: x => x.ID_Item,
                        principalTable: "Items",
                        principalColumn: "ID_Item",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderDates",
                columns: table => new
                {
                    ID_Date = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ID_Order = table.Column<long>(type: "bigint", nullable: false),
                    ID_Status = table.Column<byte>(type: "smallint", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDates", x => x.ID_Date);
                    table.ForeignKey(
                        name: "FK_OrderDates_Orders",
                        column: x => x.ID_Order,
                        principalTable: "Orders",
                        principalColumn: "ID_Order",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDates_Status",
                        column: x => x.ID_Status,
                        principalTable: "Status",
                        principalColumn: "ID_Status",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderQuantities",
                columns: table => new
                {
                    ID_Order = table.Column<long>(type: "bigint", nullable: false),
                    ID_Item = table.Column<string>(type: "text", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderQuantities", x => new { x.ID_Order, x.ID_Item });
                    table.ForeignKey(
                        name: "FK_OrderQuantities_Items",
                        column: x => x.ID_Item,
                        principalTable: "Items",
                        principalColumn: "ID_Item",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderQuantities_Orders",
                        column: x => x.ID_Order,
                        principalTable: "Orders",
                        principalColumn: "ID_Order",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_ID_Client",
                table: "Addresses",
                column: "ID_Client");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ID_Brand",
                table: "Items",
                column: "ID_Brand",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDates_ID_Order",
                table: "OrderDates",
                column: "ID_Order");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDates_ID_Status",
                table: "OrderDates",
                column: "ID_Status");

            migrationBuilder.CreateIndex(
                name: "IX_OrderQuantities_ID_Item",
                table: "OrderQuantities",
                column: "ID_Item");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ID_Client",
                table: "Orders",
                column: "ID_Client");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_ID_Item",
                table: "Pictures",
                column: "ID_Item");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ID_Item",
                table: "Reviews",
                column: "ID_Item");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "OrderDates");

            migrationBuilder.DropTable(
                name: "OrderQuantities");

            migrationBuilder.DropTable(
                name: "Pictures");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
