using Microsoft.EntityFrameworkCore.Migrations;

namespace mvc_assign5.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Settlements",
                columns: table => new
                {
                    SettlementID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vState = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    vYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    vTopic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    vIndicator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    vSubMeasure = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    vAmount = table.Column<float>(type: "real", nullable: false),
                    vSource = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settlements", x => x.SettlementID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settlements");
        }
    }
}
