using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace yhctapp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSecurityReport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsNightShift",
                table: "SecurityGuardShiftReports",
                newName: "IsConfirmed");

            migrationBuilder.AlterColumn<string>(
                name: "Proposals",
                table: "SecurityGuardShiftReports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShiftType",
                table: "SecurityGuardShiftReports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShiftType",
                table: "SecurityGuardShiftReports");

            migrationBuilder.RenameColumn(
                name: "IsConfirmed",
                table: "SecurityGuardShiftReports",
                newName: "IsNightShift");

            migrationBuilder.AlterColumn<string>(
                name: "Proposals",
                table: "SecurityGuardShiftReports",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
