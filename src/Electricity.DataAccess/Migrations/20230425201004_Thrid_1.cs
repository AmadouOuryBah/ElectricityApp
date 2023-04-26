using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Electricity.DataAccess.Migrations
{
    public partial class Thrid_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoomElectricalEquipement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkingTime = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    ElectricalEquipementId = table.Column<int>(type: "int", nullable: false),
                    EquipmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomElectricalEquipement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomElectricalEquipement_ElectricalEquipments_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "ElectricalEquipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomElectricalEquipement_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomElectricalEquipement_EquipmentId",
                table: "RoomElectricalEquipement",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomElectricalEquipement_RoomId",
                table: "RoomElectricalEquipement",
                column: "RoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomElectricalEquipement");
        }
    }
}
