using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceMVC.Migrations
{
    /// <inheritdoc />
    public partial class Isdeletedforalltablesthatneedit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOnUtc",
                table: "ProductType",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOnUtc",
                table: "ProductType",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ProductType",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOnUtc",
                table: "ProductType",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOnUtc",
                table: "PaymentMethod",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOnUtc",
                table: "PaymentMethod",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PaymentMethod",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOnUtc",
                table: "PaymentMethod",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOnUtc",
                table: "OrderStatus",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOnUtc",
                table: "OrderStatus",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "OrderStatus",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOnUtc",
                table: "OrderStatus",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOnUtc",
                table: "OrderDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOnUtc",
                table: "OrderDetails",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCanceled",
                table: "OrderDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "OrderDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOnUtc",
                table: "Country",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Country",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOnUtc",
                table: "Complaint",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOnUtc",
                table: "Complaint",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Complaint",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOnUtc",
                table: "Brand",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOnUtc",
                table: "Brand",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Brand",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOnUtc",
                table: "Brand",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOnUtc",
                table: "Address",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Address",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOnUtc",
                table: "Address",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOnUtc",
                table: "ProductType");

            migrationBuilder.DropColumn(
                name: "DeletedOnUtc",
                table: "ProductType");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ProductType");

            migrationBuilder.DropColumn(
                name: "UpdatedOnUtc",
                table: "ProductType");

            migrationBuilder.DropColumn(
                name: "CreatedOnUtc",
                table: "PaymentMethod");

            migrationBuilder.DropColumn(
                name: "DeletedOnUtc",
                table: "PaymentMethod");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PaymentMethod");

            migrationBuilder.DropColumn(
                name: "UpdatedOnUtc",
                table: "PaymentMethod");

            migrationBuilder.DropColumn(
                name: "CreatedOnUtc",
                table: "OrderStatus");

            migrationBuilder.DropColumn(
                name: "DeletedOnUtc",
                table: "OrderStatus");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "OrderStatus");

            migrationBuilder.DropColumn(
                name: "UpdatedOnUtc",
                table: "OrderStatus");

            migrationBuilder.DropColumn(
                name: "CreatedOnUtc",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "DeletedOnUtc",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "IsCanceled",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "DeletedOnUtc",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "CreatedOnUtc",
                table: "Complaint");

            migrationBuilder.DropColumn(
                name: "DeletedOnUtc",
                table: "Complaint");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Complaint");

            migrationBuilder.DropColumn(
                name: "CreatedOnUtc",
                table: "Brand");

            migrationBuilder.DropColumn(
                name: "DeletedOnUtc",
                table: "Brand");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Brand");

            migrationBuilder.DropColumn(
                name: "UpdatedOnUtc",
                table: "Brand");

            migrationBuilder.DropColumn(
                name: "DeletedOnUtc",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "UpdatedOnUtc",
                table: "Address");
        }
    }
}
