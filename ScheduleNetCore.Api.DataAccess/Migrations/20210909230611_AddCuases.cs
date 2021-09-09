using Microsoft.EntityFrameworkCore.Migrations;

namespace ScheduleNetCore.Api.DataAccess.Migrations
{
    public partial class AddCuases : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cause",
                columns: table => new
                {
                    CauseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientScheduleId = table.Column<int>(type: "int", nullable: false),
                    CauseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Low = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cause", x => x.CauseId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cause");
        }
    }
}
