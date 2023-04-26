using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceMVC.Migrations
{
    /// <inheritdoc />
    public partial class ChangeBrandLogic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductItem_Brand_BrandId",
                table: "ProductItem");

            migrationBuilder.DropIndex(
                name: "IX_ProductItem_BrandId",
                table: "ProductItem");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "ProductItem");

            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_BrandId",
                table: "Product",
                column: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Brand_BrandId",
                table: "Product",
                column: "BrandId",
                principalTable: "Brand",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Brand_BrandId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_BrandId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "Product");

            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                table: "ProductItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductItem_BrandId",
                table: "ProductItem",
                column: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductItem_Brand_BrandId",
                table: "ProductItem",
                column: "BrandId",
                principalTable: "Brand",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
