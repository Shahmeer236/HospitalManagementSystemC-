using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class X2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LabTestReports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrescribedTestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateOfReport = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Charges = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReportDetails = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabTestReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LabTestReports_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LabTestReports_PrescribedTests_PrescribedTestId",
                        column: x => x.PrescribedTestId,
                        principalTable: "PrescribedTests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LabTestReports_PatientId",
                table: "LabTestReports",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_LabTestReports_PrescribedTestId",
                table: "LabTestReports",
                column: "PrescribedTestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LabTestReports");
        }
    }
}
