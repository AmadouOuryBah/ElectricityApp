using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Electricity.DataAccess.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Area",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "WorkingTime",
                table: "RoomElectricalEquipements");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Area",
                table: "Rooms",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "WorkingTime",
                table: "RoomElectricalEquipements",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
