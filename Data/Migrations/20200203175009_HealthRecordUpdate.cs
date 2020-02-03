using Microsoft.EntityFrameworkCore.Migrations;

namespace KenkoApp.Data.Migrations
{
    public partial class HealthRecordUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MimeType",
                table: "HealthRecords");

            migrationBuilder.AddColumn<string>(
                name: "FileType",
                table: "HealthRecords",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecordNotes",
                table: "HealthRecords",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileType",
                table: "HealthRecords");

            migrationBuilder.DropColumn(
                name: "RecordNotes",
                table: "HealthRecords");

            migrationBuilder.AddColumn<string>(
                name: "MimeType",
                table: "HealthRecords",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
