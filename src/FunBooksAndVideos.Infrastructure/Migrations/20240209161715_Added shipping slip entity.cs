using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FunBooksAndVideos.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Addedshippingslipentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemLines_PurchaseOrders_PurchaseOrderID",
                table: "ItemLines");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrders_Membership_MembershipId",
                table: "PurchaseOrders");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseOrders_MembershipId",
                table: "PurchaseOrders");

            migrationBuilder.DropColumn(
                name: "MembershipId",
                table: "PurchaseOrders");

            migrationBuilder.RenameColumn(
                name: "PurchaseOrderID",
                table: "PurchaseOrders",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PurchaseOrderID",
                table: "ItemLines",
                newName: "PurchaseOrderId");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "ItemLines",
                newName: "ProductType");

            migrationBuilder.RenameIndex(
                name: "IX_ItemLines_PurchaseOrderID",
                table: "ItemLines",
                newName: "IX_ItemLines_PurchaseOrderId");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "Membership",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "PurchaseOrderId",
                table: "ItemLines",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MembershipType",
                table: "ItemLines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ShippingSlips",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShippingDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingSlips", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_CustomerId",
                table: "PurchaseOrders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Membership_CustomerId",
                table: "Membership",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemLines_PurchaseOrders_PurchaseOrderId",
                table: "ItemLines",
                column: "PurchaseOrderId",
                principalTable: "PurchaseOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Membership_Customers_CustomerId",
                table: "Membership",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrders_Customers_CustomerId",
                table: "PurchaseOrders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemLines_PurchaseOrders_PurchaseOrderId",
                table: "ItemLines");

            migrationBuilder.DropForeignKey(
                name: "FK_Membership_Customers_CustomerId",
                table: "Membership");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrders_Customers_CustomerId",
                table: "PurchaseOrders");

            migrationBuilder.DropTable(
                name: "ShippingSlips");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseOrders_CustomerId",
                table: "PurchaseOrders");

            migrationBuilder.DropIndex(
                name: "IX_Membership_CustomerId",
                table: "Membership");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Membership");

            migrationBuilder.DropColumn(
                name: "MembershipType",
                table: "ItemLines");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PurchaseOrders",
                newName: "PurchaseOrderID");

            migrationBuilder.RenameColumn(
                name: "PurchaseOrderId",
                table: "ItemLines",
                newName: "PurchaseOrderID");

            migrationBuilder.RenameColumn(
                name: "ProductType",
                table: "ItemLines",
                newName: "Type");

            migrationBuilder.RenameIndex(
                name: "IX_ItemLines_PurchaseOrderId",
                table: "ItemLines",
                newName: "IX_ItemLines_PurchaseOrderID");

            migrationBuilder.AddColumn<Guid>(
                name: "MembershipId",
                table: "PurchaseOrders",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "PurchaseOrderID",
                table: "ItemLines",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_MembershipId",
                table: "PurchaseOrders",
                column: "MembershipId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemLines_PurchaseOrders_PurchaseOrderID",
                table: "ItemLines",
                column: "PurchaseOrderID",
                principalTable: "PurchaseOrders",
                principalColumn: "PurchaseOrderID");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrders_Membership_MembershipId",
                table: "PurchaseOrders",
                column: "MembershipId",
                principalTable: "Membership",
                principalColumn: "Id");
        }
    }
}
