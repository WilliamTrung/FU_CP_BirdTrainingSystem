using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppCore.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FKConsulting564465",
                table: "ConsultingTicket");

            migrationBuilder.AddColumn<decimal>(
                name: "ConsultingPricePolicyCalculate",
                table: "ConsultingTicket",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DistancePriceCalculate",
                table: "ConsultingTicket",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ConsultingTicket_DistancePrice_DistancePriceId",
                table: "ConsultingTicket",
                column: "DistancePriceId",
                principalTable: "DistancePrice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsultingTicket_DistancePrice_DistancePriceId",
                table: "ConsultingTicket");

            migrationBuilder.DropColumn(
                name: "ConsultingPricePolicyCalculate",
                table: "ConsultingTicket");

            migrationBuilder.DropColumn(
                name: "DistancePriceCalculate",
                table: "ConsultingTicket");

            migrationBuilder.AddForeignKey(
                name: "FKConsulting564465",
                table: "ConsultingTicket",
                column: "DistancePriceId",
                principalTable: "DistancePrice",
                principalColumn: "Id");
        }
    }
}
