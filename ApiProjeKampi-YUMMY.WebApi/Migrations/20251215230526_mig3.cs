using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiProjeKampi_YUMMY.WebApi.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Details",
                table: "GroupReservations");

            migrationBuilder.DropColumn(
                name: "ReservationStatus",
                table: "GroupReservations");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "GroupReservations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonCount",
                table: "GroupReservations",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "GroupReservations");

            migrationBuilder.DropColumn(
                name: "PersonCount",
                table: "GroupReservations");

            migrationBuilder.AddColumn<string>(
                name: "Details",
                table: "GroupReservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReservationStatus",
                table: "GroupReservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
