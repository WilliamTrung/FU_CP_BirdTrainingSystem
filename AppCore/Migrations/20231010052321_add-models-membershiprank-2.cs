using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppCore.Migrations
{
    public partial class addmodelsmembershiprank2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MembershipRank",
                columns: new[] { "Id", "Discount", "Name", "Requirement" },
                values: new object[,]
                {
                    { 1, 0f, "Standard", 0m },
                    { 2, 0.1f, "Gold", 50000000m },
                    { 3, 0.2f, "Platinum", 100000000m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MembershipRank",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MembershipRank",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MembershipRank",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
