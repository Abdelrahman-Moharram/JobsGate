using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobsGate.Migrations
{
    /// <inheritdoc />
    public partial class AddDbRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "job");

            migrationBuilder.CreateTable(
                name: "Employers",
                schema: "job",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employers_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Industries",
                schema: "job",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Industries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobTypes",
                schema: "job",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                schema: "job",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IndustryId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Industries_IndustryId",
                        column: x => x.IndustryId,
                        principalSchema: "job",
                        principalTable: "Industries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                schema: "job",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Headline = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IndustryId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Industries_IndustryId",
                        column: x => x.IndustryId,
                        principalSchema: "job",
                        principalTable: "Industries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employees_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                schema: "job",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    Vacancies = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    Salary = table.Column<decimal>(type: "Money", nullable: true, defaultValue: 0m),
                    Experience = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    EmployerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IndustryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    JobTypeId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jobs_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "job",
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jobs_Employers_EmployerId",
                        column: x => x.EmployerId,
                        principalSchema: "job",
                        principalTable: "Employers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jobs_Industries_IndustryId",
                        column: x => x.IndustryId,
                        principalSchema: "job",
                        principalTable: "Industries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Jobs_JobTypes_JobTypeId",
                        column: x => x.JobTypeId,
                        principalSchema: "job",
                        principalTable: "JobTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobApplications",
                schema: "job",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CV = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoverLetter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobApplications_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "job",
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JobApplications_Jobs_JobId",
                        column: x => x.JobId,
                        principalSchema: "job",
                        principalTable: "Jobs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_IndustryId",
                schema: "job",
                table: "Categories",
                column: "IndustryId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_IndustryId",
                schema: "job",
                table: "Employees",
                column: "IndustryId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserId",
                schema: "job",
                table: "Employees",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Employers_UserId",
                schema: "job",
                table: "Employers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_EmployeeId",
                schema: "job",
                table: "JobApplications",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_JobId",
                schema: "job",
                table: "JobApplications",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_CategoryId",
                schema: "job",
                table: "Jobs",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_EmployerId",
                schema: "job",
                table: "Jobs",
                column: "EmployerId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_IndustryId",
                schema: "job",
                table: "Jobs",
                column: "IndustryId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_JobTypeId",
                schema: "job",
                table: "Jobs",
                column: "JobTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobApplications",
                schema: "job");

            migrationBuilder.DropTable(
                name: "Employees",
                schema: "job");

            migrationBuilder.DropTable(
                name: "Jobs",
                schema: "job");

            migrationBuilder.DropTable(
                name: "Categories",
                schema: "job");

            migrationBuilder.DropTable(
                name: "Employers",
                schema: "job");

            migrationBuilder.DropTable(
                name: "JobTypes",
                schema: "job");

            migrationBuilder.DropTable(
                name: "Industries",
                schema: "job");
        }
    }
}
