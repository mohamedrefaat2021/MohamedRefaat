using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MohamedRefaat.Infra.Data.Migrations
{
    public partial class CreateOrderAndProductRelationShip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductOrderId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductOrderId",
                table: "Orders",
                column: "ProductOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ProductOrders_ProductOrderId",
                table: "Orders",
                column: "ProductOrderId",
                principalTable: "ProductOrders",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ProductOrders_ProductOrderId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ProductOrderId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ProductOrderId",
                table: "Orders");
        }
    }
}
