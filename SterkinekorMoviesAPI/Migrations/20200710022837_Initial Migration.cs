using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SterkinekorMoviesAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    cartId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    finalTotal = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.cartId);
                });

            migrationBuilder.CreateTable(
                name: "OrderViewModels",
                columns: table => new
                {
                    orderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    paymentId = table.Column<int>(nullable: false),
                    paymentMessage = table.Column<string>(nullable: true),
                    cartId = table.Column<int>(nullable: false),
                    finalTotal = table.Column<double>(nullable: false),
                    id = table.Column<int>(nullable: false),
                    title = table.Column<string>(nullable: true),
                    itemCost = table.Column<double>(nullable: false),
                    quantity = table.Column<int>(nullable: false),
                    totalCost = table.Column<double>(nullable: false),
                    OrderStatus = table.Column<string>(nullable: true),
                    OrderDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderViewModels", x => x.orderId);
                });

            migrationBuilder.CreateTable(
                name: "PaymentViewModels",
                columns: table => new
                {
                    paymentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    paymentMessage = table.Column<string>(nullable: true),
                    id = table.Column<int>(nullable: false),
                    title = table.Column<string>(nullable: true),
                    itemCost = table.Column<double>(nullable: false),
                    quantity = table.Column<int>(nullable: false),
                    totalCost = table.Column<double>(nullable: false),
                    cartId = table.Column<int>(nullable: false),
                    finalTotal = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentViewModels", x => x.paymentId);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cartId = table.Column<int>(nullable: false),
                    title = table.Column<string>(nullable: true),
                    quantity = table.Column<int>(nullable: false),
                    itemCost = table.Column<double>(nullable: false),
                    totalCost = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.id);
                    table.ForeignKey(
                        name: "FK_Item_Cart_cartId",
                        column: x => x.cartId,
                        principalTable: "Cart",
                        principalColumn: "cartId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    paymentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    paymentMessage = table.Column<string>(nullable: true),
                    id = table.Column<int>(nullable: false),
                    cartId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.paymentId);
                    table.ForeignKey(
                        name: "FK_Payment_Cart_cartId",
                        column: x => x.cartId,
                        principalTable: "Cart",
                        principalColumn: "cartId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payment_Item_id",
                        column: x => x.id,
                        principalTable: "Item",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    orderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    paymentId = table.Column<int>(nullable: false),
                    cartId = table.Column<int>(nullable: false),
                    id = table.Column<int>(nullable: false),
                    OrderStatus = table.Column<string>(nullable: true),
                    OrderDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.orderId);
                    table.ForeignKey(
                        name: "FK_Order_Cart_cartId",
                        column: x => x.cartId,
                        principalTable: "Cart",
                        principalColumn: "cartId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Item_id",
                        column: x => x.id,
                        principalTable: "Item",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Payment_paymentId",
                        column: x => x.paymentId,
                        principalTable: "Payment",
                        principalColumn: "paymentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Item_cartId",
                table: "Item",
                column: "cartId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_cartId",
                table: "Order",
                column: "cartId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_id",
                table: "Order",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_paymentId",
                table: "Order",
                column: "paymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_cartId",
                table: "Payment",
                column: "cartId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_id",
                table: "Payment",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "OrderViewModels");

            migrationBuilder.DropTable(
                name: "PaymentViewModels");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Cart");
        }
    }
}
