using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class XX01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Admissions_AdmissionId",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Patients_PatientId",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_Bills_PrescribedMedicines_PrescribedMedicineId",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_Bills_PrescribedTests_PrescribedTestId",
                table: "Bills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bills",
                table: "Bills");

            migrationBuilder.DropIndex(
                name: "IX_Bills_PrescribedMedicineId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "PrescribedMedicineId",
                table: "Bills");

            migrationBuilder.RenameTable(
                name: "Bills",
                newName: "Bill");

            migrationBuilder.RenameColumn(
                name: "PrescribedTestId",
                table: "Bill",
                newName: "LabTestReportId");

            migrationBuilder.RenameIndex(
                name: "IX_Bills_PrescribedTestId",
                table: "Bill",
                newName: "IX_Bill_LabTestReportId");

            migrationBuilder.RenameIndex(
                name: "IX_Bills_PatientId",
                table: "Bill",
                newName: "IX_Bill_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_Bills_AdmissionId",
                table: "Bill",
                newName: "IX_Bill_AdmissionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bill",
                table: "Bill",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bill_Admissions_AdmissionId",
                table: "Bill",
                column: "AdmissionId",
                principalTable: "Admissions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bill_LabTestReports_LabTestReportId",
                table: "Bill",
                column: "LabTestReportId",
                principalTable: "LabTestReports",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bill_Patients_PatientId",
                table: "Bill",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bill_Admissions_AdmissionId",
                table: "Bill");

            migrationBuilder.DropForeignKey(
                name: "FK_Bill_LabTestReports_LabTestReportId",
                table: "Bill");

            migrationBuilder.DropForeignKey(
                name: "FK_Bill_Patients_PatientId",
                table: "Bill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bill",
                table: "Bill");

            migrationBuilder.RenameTable(
                name: "Bill",
                newName: "Bills");

            migrationBuilder.RenameColumn(
                name: "LabTestReportId",
                table: "Bills",
                newName: "PrescribedTestId");

            migrationBuilder.RenameIndex(
                name: "IX_Bill_PatientId",
                table: "Bills",
                newName: "IX_Bills_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_Bill_LabTestReportId",
                table: "Bills",
                newName: "IX_Bills_PrescribedTestId");

            migrationBuilder.RenameIndex(
                name: "IX_Bill_AdmissionId",
                table: "Bills",
                newName: "IX_Bills_AdmissionId");

            migrationBuilder.AddColumn<Guid>(
                name: "PrescribedMedicineId",
                table: "Bills",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bills",
                table: "Bills",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_PrescribedMedicineId",
                table: "Bills",
                column: "PrescribedMedicineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Admissions_AdmissionId",
                table: "Bills",
                column: "AdmissionId",
                principalTable: "Admissions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Patients_PatientId",
                table: "Bills",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_PrescribedMedicines_PrescribedMedicineId",
                table: "Bills",
                column: "PrescribedMedicineId",
                principalTable: "PrescribedMedicines",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_PrescribedTests_PrescribedTestId",
                table: "Bills",
                column: "PrescribedTestId",
                principalTable: "PrescribedTests",
                principalColumn: "Id");
        }
    }
}
