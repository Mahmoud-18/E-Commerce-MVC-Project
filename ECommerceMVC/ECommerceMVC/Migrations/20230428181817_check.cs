using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceMVC.Migrations
{
    /// <inheritdoc />
    public partial class check : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingBagItem_ShoppingBag_ShoppingBagId",
                table: "ShoppingBagItem");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingBag_CustomerId",
                table: "ShoppingBag");

            migrationBuilder.AddColumn<int>(
                name: "ShoppingBagId1",
                table: "ShoppingBagItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ShoppingBagId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingBagItem_ShoppingBagId1",
                table: "ShoppingBagItem",
                column: "ShoppingBagId1");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingBag_CustomerId",
                table: "ShoppingBag",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ShoppingBagId",
                table: "AspNetUsers",
                column: "ShoppingBagId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ShoppingBagItem_ShoppingBagId",
                table: "AspNetUsers",
                column: "ShoppingBagId",
                principalTable: "ShoppingBagItem",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingBagItem_ShoppingBagItem_ShoppingBagId",
                table: "ShoppingBagItem",
                column: "ShoppingBagId",
                principalTable: "ShoppingBagItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingBagItem_ShoppingBag_ShoppingBagId1",
                table: "ShoppingBagItem",
                column: "ShoppingBagId1",
                principalTable: "ShoppingBag",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ShoppingBagItem_ShoppingBagId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingBagItem_ShoppingBagItem_ShoppingBagId",
                table: "ShoppingBagItem");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingBagItem_ShoppingBag_ShoppingBagId1",
                table: "ShoppingBagItem");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingBagItem_ShoppingBagId1",
                table: "ShoppingBagItem");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingBag_CustomerId",
                table: "ShoppingBag");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ShoppingBagId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ShoppingBagId1",
                table: "ShoppingBagItem");

            migrationBuilder.DropColumn(
                name: "ShoppingBagId",
                table: "AspNetUsers");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingBag_CustomerId",
                table: "ShoppingBag",
                column: "CustomerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingBagItem_ShoppingBag_ShoppingBagId",
                table: "ShoppingBagItem",
                column: "ShoppingBagId",
                principalTable: "ShoppingBag",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
