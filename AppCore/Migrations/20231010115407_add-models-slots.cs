using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppCore.Migrations
{
    public partial class addmodelsslots : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Slot",
                columns: new[] { "Id", "EndTime", "StartTime" },
                values: new object[,]
                {
                    { 1, new TimeSpan(0, 8, 45, 0, 0), new TimeSpan(0, 8, 0, 0, 0) },
                    { 2, new TimeSpan(0, 9, 45, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 3, new TimeSpan(0, 10, 45, 0, 0), new TimeSpan(0, 10, 0, 0, 0) },
                    { 4, new TimeSpan(0, 11, 45, 0, 0), new TimeSpan(0, 11, 0, 0, 0) },
                    { 5, new TimeSpan(0, 13, 45, 0, 0), new TimeSpan(0, 13, 0, 0, 0) },
                    { 6, new TimeSpan(0, 14, 45, 0, 0), new TimeSpan(0, 14, 0, 0, 0) },
                    { 7, new TimeSpan(0, 15, 45, 0, 0), new TimeSpan(0, 15, 0, 0, 0) },
                    { 8, new TimeSpan(0, 16, 45, 0, 0), new TimeSpan(0, 16, 0, 0, 0) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Slot",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Slot",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Slot",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Slot",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Slot",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Slot",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Slot",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Slot",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
