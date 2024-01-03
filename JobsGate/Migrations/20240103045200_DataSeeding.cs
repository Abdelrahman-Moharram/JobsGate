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
                schema: "job",
                table: "JobTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "28106627-c5e6-4156-a421-d57dd6028c22", "Remote" },
                    { "8b2d2f09-200f-4c93-9f2b-494e00957053", "Full Time" },
                    { "b7763067-d390-472e-b37f-90dc2104202c", "Part Time" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "274d41cc-5ae8-497b-a5dc-40689e885a81", null, "Admin", "ADMIN" },
                    { "28e4b1e3-386e-48f2-8f28-a625120c8978", null, "Employee", "EMPLOYEE" },
                    { "490b1f92-896a-4a7e-b3fa-b2ab55a07d08", null, "Employer", "EMPLOYER" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "Image", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "city", "region" },
                values: new object[] { "06f392af-9286-4a5f-ac9a-0668130f427d", 0, null, "70a30acd-569a-4683-9fd3-2a663b878882", "admin@site.com", true, "img/users/user.webp", false, null, "admin@site.com", "Admin", "AQAAAAIAAYagAAAAEJ8ErdTyQ0WMQ0X/TIJjI8JUvjqdP7xMDZoX60UmDVdzkZhx4yoOIKCvGfK71aCRAw==", null, false, "", false, "Admin", null, null });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "274d41cc-5ae8-497b-a5dc-40689e885a81", "06f392af-9286-4a5f-ac9a-0668130f427d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "job",
                table: "JobTypes",
                keyColumn: "Id",
                keyValue: "28106627-c5e6-4156-a421-d57dd6028c22");

            migrationBuilder.DeleteData(
                schema: "job",
                table: "JobTypes",
                keyColumn: "Id",
                keyValue: "8b2d2f09-200f-4c93-9f2b-494e00957053");

            migrationBuilder.DeleteData(
                schema: "job",
                table: "JobTypes",
                keyColumn: "Id",
                keyValue: "b7763067-d390-472e-b37f-90dc2104202c");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "28e4b1e3-386e-48f2-8f28-a625120c8978");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "490b1f92-896a-4a7e-b3fa-b2ab55a07d08");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "274d41cc-5ae8-497b-a5dc-40689e885a81", "06f392af-9286-4a5f-ac9a-0668130f427d" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "274d41cc-5ae8-497b-a5dc-40689e885a81");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Users",
                keyColumn: "Id",
                keyValue: "06f392af-9286-4a5f-ac9a-0668130f427d");
        }
    }
}
