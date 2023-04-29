using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceMVC.Migrations
{
    /// <inheritdoc />
    public partial class PriceinProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Product",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
                    
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Product");
        }
    }
}
