using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderFoodOnlineSystem.Migrations
{
    /// <inheritdoc />
    public partial class seedAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "80d9c265-64a3-4520-9b0f-164d5bfc6afa", 0, "53f4f840-6448-4fbb-ab15-9ac7eb688f7c", "admin@gmail.com", true, true, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEP+ErsHGwsjLiP/LeNa9G+xKOOemIaOnBdvBGXNFiaMcQBaiEgeYqZXw19IN2yfGfQ==", null, false, "52a4b8bd-9804-45d3-9125-32df5869fab8", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "AccountId", "IsDeleted", "Name" },
                values: new object[] { 1, "80d9c265-64a3-4520-9b0f-164d5bfc6afa", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "8b06abb5-8df6-4b7f-8eb4-91344791938e", "80d9c265-64a3-4520-9b0f-164d5bfc6afa" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8b06abb5-8df6-4b7f-8eb4-91344791938e", "80d9c265-64a3-4520-9b0f-164d5bfc6afa" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80d9c265-64a3-4520-9b0f-164d5bfc6afa");
        }
    }
}
