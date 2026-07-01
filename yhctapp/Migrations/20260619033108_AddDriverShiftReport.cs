using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace yhctapp.Migrations
{
    /// <inheritdoc />
    public partial class AddDriverShiftReport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DriverShiftReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShiftType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DriverName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LicensePlate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StartingMileage = table.Column<int>(type: "int", nullable: false),
                    RegistrationPaper = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InspectionCertificate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriorityCertificate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsuranceCertificate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dashcam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AirConditioner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TirePressure = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpareTire = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExteriorInspection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LightsAndWipers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrakesAndSteering = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FireExtinguisherAndFirstAid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JackAndWrench = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Battery = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gasoline = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Diesel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotorOil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Coolant = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Oxygen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleHygiene = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndingMileage = table.Column<int>(type: "int", nullable: false),
                    HospitalTransferCount = table.Column<int>(type: "int", nullable: false),
                    OutsideEmergencyCount = table.Column<int>(type: "int", nullable: false),
                    AdminWorkCount = table.Column<int>(type: "int", nullable: false),
                    Incidents = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverShiftReports", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DriverShiftReports");
        }
    }
}
