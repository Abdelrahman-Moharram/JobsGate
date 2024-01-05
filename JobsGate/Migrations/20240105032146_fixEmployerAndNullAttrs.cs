using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JobsGate.Migrations
{
    /// <inheritdoc />
    public partial class fixEmployerAndNullAttrs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Industries_IndustryId",
                schema: "job",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Categories_CategoryId",
                schema: "job",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Employeers_EmployeerId",
                schema: "job",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_JobTypes_JobTypeId",
                schema: "job",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_EmployeerId",
                schema: "job",
                table: "Jobs");

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

            migrationBuilder.DropColumn(
                name: "EmployeerId",
                schema: "job",
                table: "Jobs");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "job",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Salary",
                schema: "job",
                table: "Jobs",
                type: "Money",
                nullable: true,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "Money");

            migrationBuilder.AlterColumn<string>(
                name: "JobTypeId",
                schema: "job",
                table: "Jobs",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IndustryId",
                schema: "job",
                table: "Jobs",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "job",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CategoryId",
                schema: "job",
                table: "Jobs",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployerId",
                schema: "job",
                table: "Jobs",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "job",
                table: "Industries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IndustryId",
                schema: "job",
                table: "Categories",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.InsertData(
                schema: "job",
                table: "JobTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "0512818f-a6bc-4455-9ea7-64cf7684fefa", "Remote" },
                    { "e3ffb6bb-2bb8-419c-8b0f-cb72f1660961", "Full Time" },
                    { "f7bdfcf0-de67-4950-a346-c1582a695c2c", "Part Time" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "57a58a0b-c6b6-417c-ab64-5aecb86150b6", null, "Admin", "ADMIN" },
                    { "ec800d8a-6bdb-4acb-8945-fef6d77475ee", null, "Employee", "EMPLOYEE" },
                    { "f625d819-3400-4b1d-9026-55ada6f9e0ac", null, "Employer", "EMPLOYER" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "Image", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "city", "region" },
                values: new object[] { "51bb59cf-075a-4328-91eb-98da24fa392d", 0, null, "b778cd18-49bc-47b3-a6c7-31c58a3d8b6f", "admin@site.com", true, "img/users/user.webp", false, null, "admin@site.com", "Admin", "AQAAAAIAAYagAAAAEMHebhuJdKbC2f0VXtcSEYARqd2Vs0mHQTXwLE7DMttARPAKExx/1nK7+vsXQmYnWw==", null, false, "", false, "Admin", null, null });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "57a58a0b-c6b6-417c-ab64-5aecb86150b6", "51bb59cf-075a-4328-91eb-98da24fa392d" });

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_EmployerId",
                schema: "job",
                table: "Jobs",
                column: "EmployerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Industries_IndustryId",
                schema: "job",
                table: "Categories",
                column: "IndustryId",
                principalSchema: "job",
                principalTable: "Industries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Categories_CategoryId",
                schema: "job",
                table: "Jobs",
                column: "CategoryId",
                principalSchema: "job",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Employeers_EmployerId",
                schema: "job",
                table: "Jobs",
                column: "EmployerId",
                principalSchema: "job",
                principalTable: "Employeers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_JobTypes_JobTypeId",
                schema: "job",
                table: "Jobs",
                column: "JobTypeId",
                principalSchema: "job",
                principalTable: "JobTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Industries_IndustryId",
                schema: "job",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Categories_CategoryId",
                schema: "job",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Employeers_EmployerId",
                schema: "job",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_JobTypes_JobTypeId",
                schema: "job",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_EmployerId",
                schema: "job",
                table: "Jobs");

            migrationBuilder.DeleteData(
                schema: "job",
                table: "JobTypes",
                keyColumn: "Id",
                keyValue: "0512818f-a6bc-4455-9ea7-64cf7684fefa");

            migrationBuilder.DeleteData(
                schema: "job",
                table: "JobTypes",
                keyColumn: "Id",
                keyValue: "e3ffb6bb-2bb8-419c-8b0f-cb72f1660961");

            migrationBuilder.DeleteData(
                schema: "job",
                table: "JobTypes",
                keyColumn: "Id",
                keyValue: "f7bdfcf0-de67-4950-a346-c1582a695c2c");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "ec800d8a-6bdb-4acb-8945-fef6d77475ee");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "f625d819-3400-4b1d-9026-55ada6f9e0ac");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "57a58a0b-c6b6-417c-ab64-5aecb86150b6", "51bb59cf-075a-4328-91eb-98da24fa392d" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "57a58a0b-c6b6-417c-ab64-5aecb86150b6");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Users",
                keyColumn: "Id",
                keyValue: "51bb59cf-075a-4328-91eb-98da24fa392d");

            migrationBuilder.DropColumn(
                name: "EmployerId",
                schema: "job",
                table: "Jobs");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "job",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Salary",
                schema: "job",
                table: "Jobs",
                type: "Money",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "Money",
                oldNullable: true,
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "JobTypeId",
                schema: "job",
                table: "Jobs",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "IndustryId",
                schema: "job",
                table: "Jobs",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "job",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryId",
                schema: "job",
                table: "Jobs",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "EmployeerId",
                schema: "job",
                table: "Jobs",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "job",
                table: "Industries",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "IndustryId",
                schema: "job",
                table: "Categories",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_EmployeerId",
                schema: "job",
                table: "Jobs",
                column: "EmployeerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Industries_IndustryId",
                schema: "job",
                table: "Categories",
                column: "IndustryId",
                principalSchema: "job",
                principalTable: "Industries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Categories_CategoryId",
                schema: "job",
                table: "Jobs",
                column: "CategoryId",
                principalSchema: "job",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Employeers_EmployeerId",
                schema: "job",
                table: "Jobs",
                column: "EmployeerId",
                principalSchema: "job",
                principalTable: "Employeers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_JobTypes_JobTypeId",
                schema: "job",
                table: "Jobs",
                column: "JobTypeId",
                principalSchema: "job",
                principalTable: "JobTypes",
                principalColumn: "Id");
        }
    }
}
