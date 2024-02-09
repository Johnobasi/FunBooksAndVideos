using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FunBooksAndVideos.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addedcustomerlogic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MembershipId",
                table: "PurchaseOrders",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MembershipId",
                table: "Customers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Membership",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MembershipType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membership", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_MembershipId",
                table: "PurchaseOrders",
                column: "MembershipId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_MembershipId",
                table: "Customers",
                column: "MembershipId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Membership_MembershipId",
                table: "Customers",
                column: "MembershipId",
                principalTable: "Membership",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrders_Membership_MembershipId",
                table: "PurchaseOrders",
                column: "MembershipId",
                principalTable: "Membership",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Membership_MembershipId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrders_Membership_MembershipId",
                table: "PurchaseOrders");

            migrationBuilder.DropTable(
                name: "Membership");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseOrders_MembershipId",
                table: "PurchaseOrders");

            migrationBuilder.DropIndex(
                name: "IX_Customers_MembershipId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "MembershipId",
                table: "PurchaseOrders");

            migrationBuilder.DropColumn(
                name: "MembershipId",
                table: "Customers");
        }
    }
}
