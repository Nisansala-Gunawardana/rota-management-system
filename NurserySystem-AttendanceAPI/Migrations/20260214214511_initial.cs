using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NurserySystem_AttendanceAPI.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BreakTimes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DurationMinutes = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreakTimes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmpAbsentDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AbsentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpAbsentDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmpShiftDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EMPId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WorkingDay = table.Column<int>(type: "int", nullable: false),
                    WorkShift = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShiftStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpShiftDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RotaDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WeekSdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WorkDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WorkShift = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    WorkingHours = table.Column<float>(type: "real", nullable: false),
                    BreakTimeId = table.Column<int>(type: "int", nullable: false),
                    FinalizedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RoomDetailsId = table.Column<int>(type: "int", nullable: false),
                    BreakTimesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RotaDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RotaDetails_BreakTimes_BreakTimesId",
                        column: x => x.BreakTimesId,
                        principalTable: "BreakTimes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RotaDetails_RoomDetails_RoomDetailsId",
                        column: x => x.RoomDetailsId,
                        principalTable: "RoomDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmpAbsentDetails_EmpId_AbsentDate",
                table: "EmpAbsentDetails",
                columns: new[] { "EmpId", "AbsentDate" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmpShiftDetails_EMPId_WorkingDay",
                table: "EmpShiftDetails",
                columns: new[] { "EMPId", "WorkingDay" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RotaDetails_BreakTimesId",
                table: "RotaDetails",
                column: "BreakTimesId");

            migrationBuilder.CreateIndex(
                name: "IX_RotaDetails_EmpId_WeekSdate_WorkDate",
                table: "RotaDetails",
                columns: new[] { "EmpId", "WeekSdate", "WorkDate" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RotaDetails_RoomDetailsId",
                table: "RotaDetails",
                column: "RoomDetailsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpAbsentDetails");

            migrationBuilder.DropTable(
                name: "EmpShiftDetails");

            migrationBuilder.DropTable(
                name: "RotaDetails");

            migrationBuilder.DropTable(
                name: "BreakTimes");

            migrationBuilder.DropTable(
                name: "RoomDetails");
        }
    }
}
