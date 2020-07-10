using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SterkinekorMoviesAPI.Migrations
{
    public partial class Migration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    orderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cartId = table.Column<int>(type: "int", nullable: false),
                    id = table.Column<int>(type: "int", nullable: false),
                    paymentId = table.Column<int>(type: "int", nullable: false)
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
        }
    }
}
