using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace yhctapp.Migrations
{
    /// <inheritdoc />
    public partial class AddSecurityGuardShiftReport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.CreateTable(
                name: "SecurityGuardShiftReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsNightShift = table.Column<bool>(type: "bit", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShiftLeaderName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ShiftPositions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityTasks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatrolTasks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParkingTasks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PropertyTasks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HandoverTasks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Proposals = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityGuardShiftReports", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SecurityGuardShiftReports");

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    Id_booking = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_user = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Bookingdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    DiscountAmount = table.Column<int>(type: "int", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    totalprice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.Id_booking);
                    table.ForeignKey(
                        name: "FK_Booking_AspNetUsers_Id_user",
                        column: x => x.Id_user,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "catogeryservices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Thumnail = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_catogeryservices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bookingdetail",
                columns: table => new
                {
                    Id_bookingdetail = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_booking = table.Column<int>(type: "int", nullable: false),
                    Id_service = table.Column<int>(type: "int", nullable: false),
                    PriceSnapshot = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookingdetail", x => x.Id_bookingdetail);
                    table.ForeignKey(
                        name: "FK_Bookingdetail_Booking_Id_booking",
                        column: x => x.Id_booking,
                        principalTable: "Booking",
                        principalColumn: "Id_booking",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTransaction",
                columns: table => new
                {
                    Id_Transaction = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_booking = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderCode = table.Column<long>(type: "bigint", nullable: false),
                    PaidAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PaymentMethod = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    WebhookData = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTransaction", x => x.Id_Transaction);
                    table.ForeignKey(
                        name: "FK_PaymentTransaction_Booking_Id_booking",
                        column: x => x.Id_booking,
                        principalTable: "Booking",
                        principalColumn: "Id_booking",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Servicespro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Catogeryservice = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    Description = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Thumnail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicespro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Servicespro_catogeryservices_Id_Catogeryservice",
                        column: x => x.Id_Catogeryservice,
                        principalTable: "catogeryservices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_Id_user",
                table: "Booking",
                column: "Id_user");

            migrationBuilder.CreateIndex(
                name: "IX_Bookingdetail_Id_booking",
                table: "Bookingdetail",
                column: "Id_booking");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTransaction_Id_booking",
                table: "PaymentTransaction",
                column: "Id_booking");

            migrationBuilder.CreateIndex(
                name: "IX_Servicespro_Id_Catogeryservice",
                table: "Servicespro",
                column: "Id_Catogeryservice");
        }
    }
}
