using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OrderFoodOnlineSystem.Migrations
{
    /// <inheritdoc />
    public partial class seedDataV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "007e8fc5-4751-4514-8d48-842fe1478097",
                columns: new[] { "Email", "NormalizedEmail", "NormalizedUserName", "UserName" },
                values: new object[] { "phmanager@gmail.com", "PHMANAGER@GMAIL.COM", "PHMANAGER@GMAIL.COM", "phmanager@gmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "19116f65-9e11-4b13-81b0-0b5a2f224fda",
                columns: new[] { "Email", "NormalizedEmail", "NormalizedUserName", "UserName" },
                values: new object[] { "sdmanager@gmail.com", "SDMANAGER@GMAIL.COM", "SDMANAGER@GMAIL.COM", "sdmanager@gmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "249116a4-54c9-4928-8de1-8c1c1b921695",
                columns: new[] { "Email", "NormalizedEmail", "NormalizedUserName", "UserName" },
                values: new object[] { "pjmanager@gmail.com", "PJMANAGER@GMAIL.COM", "PJMANAGER@GMAIL.COM", "pjmanager@gmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "823d613d-51f5-44d0-af8c-98a5dcf1e070",
                columns: new[] { "Email", "NormalizedEmail", "NormalizedUserName", "UserName" },
                values: new object[] { "BKmanager@gmail.com", "bkMANAGER@GMAIL.COM", "BKMANAGER@GMAIL.COM", "bkmanager@gmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cfcc4d4f-598d-48d7-985c-973ade5c4a85",
                columns: new[] { "Email", "NormalizedEmail", "NormalizedUserName", "UserName" },
                values: new object[] { "tbmanager@gmail.com", "TBMANAGER@GMAIL.COM", "TBMANAGER@GMAIL.COM", "tbmanager@gmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f7fe0044-a370-4d9f-ba89-e3c5e07dd17f",
                columns: new[] { "Email", "NormalizedEmail", "NormalizedUserName", "UserName" },
                values: new object[] { "gmanager@gmail.com", "GMANAGER@GMAIL.COM", "GMANAGER@GMAIL.COM", "gmanager@gmail.com" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "ImageUrl", "IsDeleted", "Name" },
                values: new object[] { 6, "CategoryImages/", false, "Drinks" });

            migrationBuilder.UpdateData(
                table: "RestaurantManagers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Tasty Bites Manager");

            migrationBuilder.UpdateData(
                table: "RestaurantManagers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Burger King Manager");

            migrationBuilder.UpdateData(
                table: "RestaurantManagers",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Ginger Manager");

            migrationBuilder.UpdateData(
                table: "RestaurantManagers",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "PaPa John Manager");

            migrationBuilder.UpdateData(
                table: "RestaurantManagers",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Pizza Hut Manager");

            migrationBuilder.UpdateData(
                table: "RestaurantManagers",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Sweet Delights Manager");

            migrationBuilder.InsertData(
                table: "RestaurantCategories",
                columns: new[] { "CategoryId", "RestaurantId", "IsDeleted" },
                values: new object[,]
                {
                    { 6, 1, false },
                    { 6, 2, false },
                    { 6, 4, false },
                    { 6, 5, false }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RestaurantCategories",
                keyColumns: new[] { "CategoryId", "RestaurantId" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.DeleteData(
                table: "RestaurantCategories",
                keyColumns: new[] { "CategoryId", "RestaurantId" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "RestaurantCategories",
                keyColumns: new[] { "CategoryId", "RestaurantId" },
                keyValues: new object[] { 6, 4 });

            migrationBuilder.DeleteData(
                table: "RestaurantCategories",
                keyColumns: new[] { "CategoryId", "RestaurantId" },
                keyValues: new object[] { 6, 5 });

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "007e8fc5-4751-4514-8d48-842fe1478097",
                columns: new[] { "Email", "NormalizedEmail", "NormalizedUserName", "UserName" },
                values: new object[] { "manager5@gmail.com", "MANAGER5@GMAIL.COM", "MANAGER5@GMAIL.COM", "manager5@gmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "19116f65-9e11-4b13-81b0-0b5a2f224fda",
                columns: new[] { "Email", "NormalizedEmail", "NormalizedUserName", "UserName" },
                values: new object[] { "manager6@gmail.com", "MANAGER6@GMAIL.COM", "MANAGER6@GMAIL.COM", "manager6@gmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "249116a4-54c9-4928-8de1-8c1c1b921695",
                columns: new[] { "Email", "NormalizedEmail", "NormalizedUserName", "UserName" },
                values: new object[] { "manager4@gmail.com", "MANAGER4@GMAIL.COM", "MANAGER4@GMAIL.COM", "manager4@gmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "823d613d-51f5-44d0-af8c-98a5dcf1e070",
                columns: new[] { "Email", "NormalizedEmail", "NormalizedUserName", "UserName" },
                values: new object[] { "manager2@gmail.com", "MANAGER2@GMAIL.COM", "MANAGER2@GMAIL.COM", "manager2@gmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cfcc4d4f-598d-48d7-985c-973ade5c4a85",
                columns: new[] { "Email", "NormalizedEmail", "NormalizedUserName", "UserName" },
                values: new object[] { "manager1@gmail.com", "MANAGER1@GMAIL.COM", "MANAGER1@GMAIL.COM", "manager1@gmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f7fe0044-a370-4d9f-ba89-e3c5e07dd17f",
                columns: new[] { "Email", "NormalizedEmail", "NormalizedUserName", "UserName" },
                values: new object[] { "manager3@gmail.com", "MANAGER3@GMAIL.COM", "MANAGER3@GMAIL.COM", "manager3@gmail.com" });

            migrationBuilder.UpdateData(
                table: "RestaurantManagers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Manager One");

            migrationBuilder.UpdateData(
                table: "RestaurantManagers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Manager Two");

            migrationBuilder.UpdateData(
                table: "RestaurantManagers",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Manager Three");

            migrationBuilder.UpdateData(
                table: "RestaurantManagers",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Manager Four");

            migrationBuilder.UpdateData(
                table: "RestaurantManagers",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Manager Five");

            migrationBuilder.UpdateData(
                table: "RestaurantManagers",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Manager Six");
        }
    }
}
