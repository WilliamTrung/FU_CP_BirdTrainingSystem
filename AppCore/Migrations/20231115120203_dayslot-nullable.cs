using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppCore.Migrations
{
    public partial class dayslotnullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FKWorkshopCl382995",
                table: "WorkshopClassDetail");

            migrationBuilder.AlterColumn<int>(
                name: "DaySlotId",
                table: "WorkshopClassDetail",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FKWorkshopCl382995",
                table: "WorkshopClassDetail",
                column: "DaySlotId",
                principalTable: "TrainerSlot",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FKWorkshopCl382995",
                table: "WorkshopClassDetail");

            migrationBuilder.AlterColumn<int>(
                name: "DaySlotId",
                table: "WorkshopClassDetail",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FKWorkshopCl382995",
                table: "WorkshopClassDetail",
                column: "DaySlotId",
                principalTable: "TrainerSlot",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
