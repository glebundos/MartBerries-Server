using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MartBerriesServer.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class SplitSupplierProductsFromProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SupplierProducts_Products_ProductId",
                table: "SupplierProducts");

            migrationBuilder.DropIndex(
                name: "IX_SupplierProducts_ProductId",
                table: "SupplierProducts");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "SupplierProducts");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "SupplierProducts");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "SupplierProducts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "SupplierProducts",
                type: "decimal(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "SupplierProducts");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "SupplierProducts");

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "SupplierProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "SupplierProducts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_SupplierProducts_ProductId",
                table: "SupplierProducts",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierProducts_Products_ProductId",
                table: "SupplierProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
