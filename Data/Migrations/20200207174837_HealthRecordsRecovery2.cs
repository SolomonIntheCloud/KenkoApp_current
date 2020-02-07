using Microsoft.EntityFrameworkCore.Migrations;

namespace KenkoApp.Data.Migrations
{
    public partial class HealthRecordsRecovery2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<string>(
                name: "RecordNotes",
                table: "HealthRecords",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "RecordNotes",
                table: "HealthRecords");

        }
    }
}
