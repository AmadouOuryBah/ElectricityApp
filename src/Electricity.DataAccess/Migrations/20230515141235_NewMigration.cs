using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Electricity.DataAccess.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomElectricalEquipement_ElectricalEquipments_ElectricalEquipementId",
                table: "RoomElectricalEquipement");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomElectricalEquipement_Rooms_RoomId",
                table: "RoomElectricalEquipement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomElectricalEquipement",
                table: "RoomElectricalEquipement");

            migrationBuilder.RenameTable(
                name: "RoomElectricalEquipement",
                newName: "RoomElectricalEquipements");

            migrationBuilder.RenameIndex(
                name: "IX_RoomElectricalEquipement_RoomId",
                table: "RoomElectricalEquipements",
                newName: "IX_RoomElectricalEquipements_RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_RoomElectricalEquipement_ElectricalEquipementId",
                table: "RoomElectricalEquipements",
                newName: "IX_RoomElectricalEquipements_ElectricalEquipementId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomElectricalEquipements",
                table: "RoomElectricalEquipements",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomElectricalEquipements_ElectricalEquipments_ElectricalEquipementId",
                table: "RoomElectricalEquipements",
                column: "ElectricalEquipementId",
                principalTable: "ElectricalEquipments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomElectricalEquipements_Rooms_RoomId",
                table: "RoomElectricalEquipements",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomElectricalEquipements_ElectricalEquipments_ElectricalEquipementId",
                table: "RoomElectricalEquipements");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomElectricalEquipements_Rooms_RoomId",
                table: "RoomElectricalEquipements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomElectricalEquipements",
                table: "RoomElectricalEquipements");

            migrationBuilder.RenameTable(
                name: "RoomElectricalEquipements",
                newName: "RoomElectricalEquipement");

            migrationBuilder.RenameIndex(
                name: "IX_RoomElectricalEquipements_RoomId",
                table: "RoomElectricalEquipement",
                newName: "IX_RoomElectricalEquipement_RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_RoomElectricalEquipements_ElectricalEquipementId",
                table: "RoomElectricalEquipement",
                newName: "IX_RoomElectricalEquipement_ElectricalEquipementId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomElectricalEquipement",
                table: "RoomElectricalEquipement",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomElectricalEquipement_ElectricalEquipments_ElectricalEquipementId",
                table: "RoomElectricalEquipement",
                column: "ElectricalEquipementId",
                principalTable: "ElectricalEquipments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomElectricalEquipement_Rooms_RoomId",
                table: "RoomElectricalEquipement",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
