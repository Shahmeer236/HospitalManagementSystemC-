using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class XI2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Patients_PatientId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "PaidStatus",
                table: "Bills");

            migrationBuilder.RenameColumn(
                name: "BillDate",
                table: "Bills",
                newName: "DateOfIssue");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Bills",
                newName: "TotalAmount");

            migrationBuilder.AlterColumn<decimal>(
                name: "charges",
                table: "Rooms",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "PatientId",
                table: "Bills",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "AdmissionId",
                table: "Bills",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PrescribedMedicineId",
                table: "Bills",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PrescribedTestId",
                table: "Bills",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bills_AdmissionId",
                table: "Bills",
                column: "AdmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_PrescribedMedicineId",
                table: "Bills",
                column: "PrescribedMedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_PrescribedTestId",
                table: "Bills",
                column: "PrescribedTestId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_Bills_AdmissionId",
                table: "Bills");

            migrationBuilder.DropIndex(
                name: "IX_Bills_PrescribedMedicineId",
                table: "Bills");

            migrationBuilder.DropIndex(
                name: "IX_Bills_PrescribedTestId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "AdmissionId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "PrescribedMedicineId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "PrescribedTestId",
                table: "Bills");

            migrationBuilder.RenameColumn(
                name: "TotalAmount",
                table: "Bills",
                newName: "Amount");

            migrationBuilder.RenameColumn(
                name: "DateOfIssue",
                table: "Bills",
                newName: "BillDate");

            migrationBuilder.AlterColumn<string>(
                name: "charges",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<Guid>(
                name: "PatientId",
                table: "Bills",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Bills",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "PaidStatus",
                table: "Bills",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Patients_PatientId",
                table: "Bills",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
