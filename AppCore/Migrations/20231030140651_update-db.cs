using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppCore.Migrations
{
    public partial class updatedb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsComplete",
                table: "Bird_TrainingProgress");

            migrationBuilder.AlterColumn<string>(
                name: "Picture",
                table: "OnlineCourse",
                type: "character varying(200)",
                unicode: false,
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldUnicode: false,
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TrainerId",
                table: "ConsultingTicket",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ActualSlotStart",
                table: "ConsultingTicket",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Adddress",
                table: "ConsultingTicket",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTrainingDate",
                table: "Bird_TrainingProgress",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Bird_TrainingProgress",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalTrainingSlot",
                table: "Bird_TrainingProgress",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "RegisteredDate",
                table: "Bird_TrainingCourse",
                type: "timestamp with time zone",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adddress",
                table: "ConsultingTicket");

            migrationBuilder.DropColumn(
                name: "StartTrainingDate",
                table: "Bird_TrainingProgress");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Bird_TrainingProgress");

            migrationBuilder.DropColumn(
                name: "TotalTrainingSlot",
                table: "Bird_TrainingProgress");

            migrationBuilder.DropColumn(
                name: "RegisteredDate",
                table: "Bird_TrainingCourse");

            migrationBuilder.AlterColumn<string>(
                name: "Picture",
                table: "OnlineCourse",
                type: "character varying(50)",
                unicode: false,
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldUnicode: false,
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TrainerId",
                table: "ConsultingTicket",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ActualSlotStart",
                table: "ConsultingTicket",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<bool>(
                name: "IsComplete",
                table: "Bird_TrainingProgress",
                type: "boolean",
                nullable: true);
        }
    }
}
