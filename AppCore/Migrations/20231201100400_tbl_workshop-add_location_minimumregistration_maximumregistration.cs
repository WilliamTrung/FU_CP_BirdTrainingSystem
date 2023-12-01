using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppCore.Migrations
{
    public partial class tbl_workshopadd_location_minimumregistration_maximumregistration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Workshop",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MaximumRegistration",
                table: "Workshop",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MinimumRegistration",
                table: "Workshop",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Workshop");

            migrationBuilder.DropColumn(
                name: "MaximumRegistration",
                table: "Workshop");

            migrationBuilder.DropColumn(
                name: "MinimumRegistration",
                table: "Workshop");
        }
    }
}
