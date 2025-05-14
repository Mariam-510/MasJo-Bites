using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderFoodOnlineSystem.Migrations
{
    /// <inheritdoc />
    public partial class updateCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeliveryMethod",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SelectedAddressId",
                table: "Carts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Carts_SelectedAddressId",
                table: "Carts",
                column: "SelectedAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Addresses_SelectedAddressId",
                table: "Carts",
                column: "SelectedAddressId",
                principalTable: "Addresses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Addresses_SelectedAddressId",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_SelectedAddressId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "DeliveryMethod",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "SelectedAddressId",
                table: "Carts");
        }
    }
}
