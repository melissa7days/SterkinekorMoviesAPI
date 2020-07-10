using Microsoft.EntityFrameworkCore.Migrations;

namespace SterkinekorMoviesAPI.Migrations
{
    public partial class Migration6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Cart_cartId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Item_id",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Payment_paymentId",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "OrderDetails");

            migrationBuilder.RenameIndex(
                name: "IX_Order_paymentId",
                table: "OrderDetails",
                newName: "IX_OrderDetails_paymentId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_id",
                table: "OrderDetails",
                newName: "IX_OrderDetails_id");

            migrationBuilder.RenameIndex(
                name: "IX_Order_cartId",
                table: "OrderDetails",
                newName: "IX_OrderDetails_cartId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDetails",
                table: "OrderDetails",
                column: "orderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Cart_cartId",
                table: "OrderDetails",
                column: "cartId",
                principalTable: "Cart",
                principalColumn: "cartId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Item_id",
                table: "OrderDetails",
                column: "id",
                principalTable: "Item",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Payment_paymentId",
                table: "OrderDetails",
                column: "paymentId",
                principalTable: "Payment",
                principalColumn: "paymentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Cart_cartId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Item_id",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Payment_paymentId",
                table: "OrderDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDetails",
                table: "OrderDetails");

            migrationBuilder.RenameTable(
                name: "OrderDetails",
                newName: "Order");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_paymentId",
                table: "Order",
                newName: "IX_Order_paymentId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_id",
                table: "Order",
                newName: "IX_Order_id");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_cartId",
                table: "Order",
                newName: "IX_Order_cartId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "orderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Cart_cartId",
                table: "Order",
                column: "cartId",
                principalTable: "Cart",
                principalColumn: "cartId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Item_id",
                table: "Order",
                column: "id",
                principalTable: "Item",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Payment_paymentId",
                table: "Order",
                column: "paymentId",
                principalTable: "Payment",
                principalColumn: "paymentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
