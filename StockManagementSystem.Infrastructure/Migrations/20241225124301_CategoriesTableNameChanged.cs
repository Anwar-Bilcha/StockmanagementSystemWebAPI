using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockManagementSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CategoriesTableNameChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_ProductsCategorycategoryId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "ProductCategories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCategories",
                table: "ProductCategories",
                column: "categoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductCategories_ProductsCategorycategoryId",
                table: "Products",
                column: "ProductsCategorycategoryId",
                principalTable: "ProductCategories",
                principalColumn: "categoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCategories_ProductsCategorycategoryId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCategories",
                table: "ProductCategories");

            migrationBuilder.RenameTable(
                name: "ProductCategories",
                newName: "Categories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "categoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_ProductsCategorycategoryId",
                table: "Products",
                column: "ProductsCategorycategoryId",
                principalTable: "Categories",
                principalColumn: "categoryId");
        }
    }
}
