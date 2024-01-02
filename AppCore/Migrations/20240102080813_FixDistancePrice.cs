using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppCore.Migrations
{
    public partial class FixDistancePrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConsultingPricePolicyId",
                table: "DistancePrice");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConsultingPricePolicyId",
                table: "DistancePrice",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
