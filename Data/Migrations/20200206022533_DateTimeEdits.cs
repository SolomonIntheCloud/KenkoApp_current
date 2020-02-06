using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KenkoApp.Data.Migrations
{
    public partial class DateTimeEdits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateofBirth",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    AppointmentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTime = table.Column<DateTime>(nullable: false),
                    ReasonForVisit = table.Column<string>(nullable: true),
                    PCMID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.AppointmentID);
                    table.ForeignKey(
                        name: "FK_Appointment_PCM_PCMID",
                        column: x => x.PCMID,
                        principalTable: "PCM",
                        principalColumn: "PCMID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_PCMID",
                table: "Appointment",
                column: "PCMID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointment");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateofBirth",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
