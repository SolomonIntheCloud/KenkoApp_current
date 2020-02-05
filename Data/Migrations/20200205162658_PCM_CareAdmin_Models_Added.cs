using Microsoft.EntityFrameworkCore.Migrations;

namespace KenkoApp.Data.Migrations
{
    public partial class PCM_CareAdmin_Models_Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PCMID",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CareAdministrator",
                columns: table => new
                {
                    CareAdministratorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminEmail = table.Column<string>(nullable: true),
                    AdminPassword = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CareAdministrator", x => x.CareAdministratorId);
                });

            migrationBuilder.CreateTable(
                name: "PCM",
                columns: table => new
                {
                    PCMID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pcmFName = table.Column<string>(nullable: true),
                    pcmLName = table.Column<string>(nullable: true),
                    Specialty = table.Column<string>(nullable: true),
                    CareAdministratorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PCM", x => x.PCMID);
                    table.ForeignKey(
                        name: "FK_PCM_CareAdministrator_CareAdministratorId",
                        column: x => x.CareAdministratorId,
                        principalTable: "CareAdministrator",
                        principalColumn: "CareAdministratorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PCMID",
                table: "AspNetUsers",
                column: "PCMID");

            migrationBuilder.CreateIndex(
                name: "IX_PCM_CareAdministratorId",
                table: "PCM",
                column: "CareAdministratorId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_PCM_PCMID",
                table: "AspNetUsers",
                column: "PCMID",
                principalTable: "PCM",
                principalColumn: "PCMID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_PCM_PCMID",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "PCM");

            migrationBuilder.DropTable(
                name: "CareAdministrator");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PCMID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PCMID",
                table: "AspNetUsers");
        }
    }
}
