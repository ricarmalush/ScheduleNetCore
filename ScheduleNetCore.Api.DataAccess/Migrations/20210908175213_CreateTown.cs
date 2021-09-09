using Microsoft.EntityFrameworkCore.Migrations;

namespace ScheduleNetCore.Api.DataAccess.Migrations
{
    public partial class CreateTown : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Town",
                columns: table => new
                {
                    TownId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProvinceId = table.Column<int>(type: "int", nullable: false),
                    ClientScheduleId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Low = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Town", x => x.TownId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Town");
        }
    }
}
