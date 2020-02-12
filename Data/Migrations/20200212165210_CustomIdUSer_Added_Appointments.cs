using Microsoft.EntityFrameworkCore.Migrations;

namespace KenkoApp.Data.Migrations
{
    public partial class CustomIdUSer_Added_Appointments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomIdentityUserId",
                table: "Appointment",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_CustomIdentityUserId",
                table: "Appointment",
                column: "CustomIdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_AspNetUsers_CustomIdentityUserId",
                table: "Appointment",
                column: "CustomIdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_AspNetUsers_CustomIdentityUserId",
                table: "Appointment");

            migrationBuilder.DropIndex(
                name: "IX_Appointment_CustomIdentityUserId",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "CustomIdentityUserId",
                table: "Appointment");
        }
    }
}
