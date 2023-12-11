using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppCore.Migrations
{
    public partial class UpdateTrainer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Trainer");

            migrationBuilder.AddColumn<bool>(
                name: "ConsultantAble",
                table: "Trainer",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConsultantAble",
                table: "Trainer");

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Trainer",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
