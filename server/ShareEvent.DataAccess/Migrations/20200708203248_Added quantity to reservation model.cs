using Microsoft.EntityFrameworkCore.Migrations;

namespace ShareEvent.DataAccess.Migrations
{
    public partial class Addedquantitytoreservationmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReservedQuantity",
                table: "Reservations",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReservedQuantity",
                table: "Reservations");
        }
    }
}
