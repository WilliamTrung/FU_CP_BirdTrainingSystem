using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppCore.Migrations
{
    public partial class adjustlocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Workshop");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "WorkshopClass",
                type: "character varying(512)",
                maxLength: 512,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "WorkshopClass");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Workshop",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
