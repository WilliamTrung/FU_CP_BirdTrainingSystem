using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppCore.Migrations
{
    public partial class shiftrefundfk_to_tablecustomerworkshopclass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FKWorkshop234277",
                table: "Workshop");

            migrationBuilder.DropIndex(
                name: "IX_Workshop_WorkshopRefundPolicyId",
                table: "Workshop");

            migrationBuilder.DropColumn(
                name: "WorkshopRefundPolicyId",
                table: "Workshop");

            migrationBuilder.AddColumn<int>(
                name: "WorkshopRefundPolicyId",
                table: "Customer_WorkshopClass",
                type: "integer",
                nullable: true);

            migrationBuilder.InsertData(
                table: "WorkshopRefundPolicy",
                columns: new[] { "Id", "RefundRate", "TotalDayBeforeStart" },
                values: new object[,]
                {
                    { 1, 0f, 13 },
                    { 2, 0.5f, 29 },
                    { 3, 0.75f, 30 },
                    { 4, 1f, -1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_WorkshopClass_WorkshopRefundPolicyId",
                table: "Customer_WorkshopClass",
                column: "WorkshopRefundPolicyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_WorkshopClass_WorkshopRefundPolicy_WorkshopRefundP~",
                table: "Customer_WorkshopClass",
                column: "WorkshopRefundPolicyId",
                principalTable: "WorkshopRefundPolicy",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_WorkshopClass_WorkshopRefundPolicy_WorkshopRefundP~",
                table: "Customer_WorkshopClass");

            migrationBuilder.DropIndex(
                name: "IX_Customer_WorkshopClass_WorkshopRefundPolicyId",
                table: "Customer_WorkshopClass");

            migrationBuilder.DeleteData(
                table: "WorkshopRefundPolicy",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "WorkshopRefundPolicy",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "WorkshopRefundPolicy",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "WorkshopRefundPolicy",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "WorkshopRefundPolicyId",
                table: "Customer_WorkshopClass");

            migrationBuilder.AddColumn<int>(
                name: "WorkshopRefundPolicyId",
                table: "Workshop",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Workshop_WorkshopRefundPolicyId",
                table: "Workshop",
                column: "WorkshopRefundPolicyId");

            migrationBuilder.AddForeignKey(
                name: "FKWorkshop234277",
                table: "Workshop",
                column: "WorkshopRefundPolicyId",
                principalTable: "WorkshopRefundPolicy",
                principalColumn: "Id");
        }
    }
}
