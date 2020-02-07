using Microsoft.EntityFrameworkCore.Migrations;

namespace KenkoApp.Data.Migrations
{
    public partial class HealthRecordsRecovery3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomIdentityUserId",
                table: "HealthRecords",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HealthRecords_CustomIdentityUserId",
                table: "HealthRecords",
                column: "CustomIdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_HealthRecords_AspNetUsers_CustomIdentityUserId",
                table: "HealthRecords",
                column: "CustomIdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HealthRecords_AspNetUsers_CustomIdentityUserId",
                table: "HealthRecords");

            migrationBuilder.DropIndex(
                name: "IX_HealthRecords_CustomIdentityUserId",
                table: "HealthRecords");

            migrationBuilder.DropColumn(
                name: "CustomIdentityUserId",
                table: "HealthRecords");
        }
    }
}
