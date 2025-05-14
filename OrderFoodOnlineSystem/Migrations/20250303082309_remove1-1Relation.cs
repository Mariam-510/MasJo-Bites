using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderFoodOnlineSystem.Migrations
{
    /// <inheritdoc />
    public partial class remove11Relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Carts_CartId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantManagers_Restaurants_RestaurantId",
                table: "RestaurantManagers");

            migrationBuilder.DropIndex(
                name: "IX_RestaurantManagers_RestaurantId",
                table: "RestaurantManagers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CartId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "RestaurantManagers");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "Customers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "RestaurantManagers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantManagers_RestaurantId",
                table: "RestaurantManagers",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CartId",
                table: "Customers",
                column: "CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Carts_CartId",
                table: "Customers",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantManagers_Restaurants_RestaurantId",
                table: "RestaurantManagers",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id");
        }
    }
}
