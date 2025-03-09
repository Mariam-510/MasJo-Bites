using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderFoodOnlineSystem.Migrations
{
    /// <inheritdoc />
    public partial class updates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RestaurantViewModel");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RestaurantViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestaurantManagerId = table.Column<int>(type: "int", nullable: true),
                    DateColse = table.Column<TimeOnly>(type: "time", nullable: false),
                    DateOpen = table.Column<TimeOnly>(type: "time", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsOpen = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantViewModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RestaurantViewModel_RestaurantManagers_RestaurantManagerId",
                        column: x => x.RestaurantManagerId,
                        principalTable: "RestaurantManagers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantViewModel_RestaurantManagerId",
                table: "RestaurantViewModel",
                column: "RestaurantManagerId");
        }
    }
}
