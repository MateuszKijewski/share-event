using Microsoft.EntityFrameworkCore.Migrations;

namespace ShareEvent.DataAccess.Migrations
{
    public partial class UpdatedTicketType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "TicketTypes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "TicketTypes");
        }
    }
}
