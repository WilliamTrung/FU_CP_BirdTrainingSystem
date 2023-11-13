using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppCore.Migrations
{
    public partial class changeworkshopattendance_tbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FKWorkshopAt172557",
                table: "WorkshopAttendance");

            migrationBuilder.DropForeignKey(
                name: "FKWorkshopCl382995",
                table: "WorkshopClassDetail");

            migrationBuilder.DropColumn(
                name: "AttendDate",
                table: "WorkshopAttendance");

            migrationBuilder.RenameColumn(
                name: "WorkshopClassId",
                table: "WorkshopAttendance",
                newName: "WorkshopClassDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkshopAttendance_WorkshopClassId",
                table: "WorkshopAttendance",
                newName: "IX_WorkshopAttendance_WorkshopClassDetailId");

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
                name: "FK_WorkshopAttendance_WorkshopClassDetail_WorkshopClassDetailId",
                table: "WorkshopAttendance",
                column: "WorkshopClassDetailId",
                principalTable: "WorkshopClassDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FKWorkshopCl382995",
                table: "WorkshopClassDetail",
                column: "DaySlotId",
                principalTable: "TrainerSlot",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkshopAttendance_WorkshopClassDetail_WorkshopClassDetailId",
                table: "WorkshopAttendance");

            migrationBuilder.DropForeignKey(
                name: "FKWorkshopCl382995",
                table: "WorkshopClassDetail");

            migrationBuilder.RenameColumn(
                name: "WorkshopClassDetailId",
                table: "WorkshopAttendance",
                newName: "WorkshopClassId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkshopAttendance_WorkshopClassDetailId",
                table: "WorkshopAttendance",
                newName: "IX_WorkshopAttendance_WorkshopClassId");

            migrationBuilder.AlterColumn<int>(
                name: "DaySlotId",
                table: "WorkshopClassDetail",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<DateTime>(
                name: "AttendDate",
                table: "WorkshopAttendance",
                type: "date",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FKWorkshopAt172557",
                table: "WorkshopAttendance",
                column: "WorkshopClassId",
                principalTable: "WorkshopClass",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FKWorkshopCl382995",
                table: "WorkshopClassDetail",
                column: "DaySlotId",
                principalTable: "TrainerSlot",
                principalColumn: "Id");
        }
    }
}
