using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderFoodOnlineSystem.Migrations
{
    /// <inheritdoc />
    public partial class updateDataV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateColse", "DateOpen" },
                values: new object[] { new TimeOnly(6, 0, 0), new TimeOnly(11, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateColse", "DateOpen" },
                values: new object[] { new TimeOnly(7, 0, 0), new TimeOnly(13, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateColse", "DateOpen" },
                values: new object[] { new TimeOnly(23, 0, 0), new TimeOnly(13, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateColse", "DateOpen" },
                values: new object[] { new TimeOnly(23, 0, 0), new TimeOnly(10, 0, 0) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateColse", "DateOpen" },
                values: new object[] { new TimeOnly(23, 0, 0), new TimeOnly(9, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateColse", "DateOpen" },
                values: new object[] { new TimeOnly(22, 0, 0), new TimeOnly(10, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateColse", "DateOpen" },
                values: new object[] { new TimeOnly(20, 0, 0), new TimeOnly(8, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateColse", "DateOpen" },
                values: new object[] { new TimeOnly(21, 0, 0), new TimeOnly(9, 0, 0) });
        }
    }
}
