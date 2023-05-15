using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Electricity.DataAccess.Migrations
{
    public partial class secondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomElectricalEquipement_ElectricalEquipments_ElectricalEquipmentId",
                table: "RoomElectricalEquipement");

            migrationBuilder.DropIndex(
                name: "IX_RoomElectricalEquipement_ElectricalEquipmentId",
                table: "RoomElectricalEquipement");

            migrationBuilder.DropColumn(
                name: "ElectricalEquipmentId",
                table: "RoomElectricalEquipement");

            migrationBuilder.CreateIndex(
                name: "IX_RoomElectricalEquipement_ElectricalEquipementId",
                table: "RoomElectricalEquipement",
                column: "ElectricalEquipementId");

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

            migrationBuilder.AddColumn<int>(
                name: "ElectricalEquipmentId",
                table: "RoomElectricalEquipement",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RoomElectricalEquipement_ElectricalEquipmentId",
                table: "RoomElectricalEquipement",
                column: "ElectricalEquipmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomElectricalEquipement_ElectricalEquipments_ElectricalEquipmentId",
                table: "RoomElectricalEquipement",
                column: "ElectricalEquipmentId",
                principalTable: "ElectricalEquipments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
