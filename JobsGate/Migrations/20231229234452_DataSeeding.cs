using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JobsGate.Migrations
{
    /// <inheritdoc />
    public partial class DataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3ece1275-fa26-411e-98c5-ba80bc66f978", null, "User", "USER" },
                    { "4c396984-afbb-48b4-adf1-614e060834f9", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "Image", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "city", "region" },
                values: new object[] { "2247d3e7-7410-455a-8fa6-8489f283ad96", 0, null, "ae5c02d0-b195-4a96-8c43-a5b7e1ef996a", "admin@site.com", true, "img/users/user.webp", false, null, "admin@site.com", "Admin", "AQAAAAIAAYagAAAAECI8UcGWDZpnIVdI+vFFvpFecJeq2Nm0ZYOQ2DnwouxOn/aqs2uhFIgH+BFyJxVH1w==", null, false, "", false, "Admin", null, null });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "4c396984-afbb-48b4-adf1-614e060834f9", "2247d3e7-7410-455a-8fa6-8489f283ad96" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "3ece1275-fa26-411e-98c5-ba80bc66f978");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4c396984-afbb-48b4-adf1-614e060834f9", "2247d3e7-7410-455a-8fa6-8489f283ad96" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "4c396984-afbb-48b4-adf1-614e060834f9");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Users",
                keyColumn: "Id",
                keyValue: "2247d3e7-7410-455a-8fa6-8489f283ad96");
        }
    }
}
