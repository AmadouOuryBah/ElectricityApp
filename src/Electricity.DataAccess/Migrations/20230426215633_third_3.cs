using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Electricity.DataAccess.Migrations
{
    public partial class third_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomElectricalEquipement_ElectricalEquipments_EquipmentId",
                table: "RoomElectricalEquipement");

            migrationBuilder.DropIndex(
                name: "IX_RoomElectricalEquipement_EquipmentId",
                table: "RoomElectricalEquipement");

            migrationBuilder.DropIndex(
                name: "IX_Buildings_ElectricityMeterId",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "EquipmentId",
                table: "RoomElectricalEquipement");

            migrationBuilder.CreateIndex(
                name: "IX_RoomElectricalEquipement_ElectricalEquipementId",
                table: "RoomElectricalEquipement",
                column: "ElectricalEquipementId");

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_ElectricityMeterId",
                table: "Buildings",
                column: "ElectricityMeterId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomElectricalEquipement_ElectricalEquipments_ElectricalEquipementId",
                table: "RoomElectricalEquipement",
                column: "ElectricalEquipementId",
                principalTable: "ElectricalEquipments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomElectricalEquipement_ElectricalEquipments_ElectricalEquipementId",
                table: "RoomElectricalEquipement");

            migrationBuilder.DropIndex(
                name: "IX_RoomElectricalEquipement_ElectricalEquipementId",
                table: "RoomElectricalEquipement");

            migrationBuilder.DropIndex(
                name: "IX_Buildings_ElectricityMeterId",
                table: "Buildings");

            migrationBuilder.AddColumn<int>(
                name: "EquipmentId",
                table: "RoomElectricalEquipement",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RoomElectricalEquipement_EquipmentId",
                table: "RoomElectricalEquipement",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_ElectricityMeterId",
                table: "Buildings",
                column: "ElectricityMeterId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomElectricalEquipement_ElectricalEquipments_EquipmentId",
                table: "RoomElectricalEquipement",
                column: "EquipmentId",
                principalTable: "ElectricalEquipments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
