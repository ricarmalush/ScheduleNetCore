using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ScheduleNetCore.Api.DataAccess.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientSchedule",
                columns: table => new
                {
                    ClientScheduleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HighDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Lowdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Low = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientSchedule", x => x.ClientScheduleId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientSchedule");
        }
    }
}
