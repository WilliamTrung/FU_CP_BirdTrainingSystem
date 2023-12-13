using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppCore.Migrations
{
    public partial class fixBirdTrainingReport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BirdTrainingReport_Trainer_TrainerId",
                table: "BirdTrainingReport");

            migrationBuilder.DropIndex(
                name: "IX_BirdTrainingReport_TrainerId",
                table: "BirdTrainingReport");

            migrationBuilder.DropColumn(
                name: "TrainerId",
                table: "BirdTrainingReport");

            migrationBuilder.UpdateData(
                table: "MembershipRank",
                keyColumn: "Id",
                keyValue: 2,
                column: "Requirement",
                value: 5000000m);

            migrationBuilder.UpdateData(
                table: "MembershipRank",
                keyColumn: "Id",
                keyValue: 3,
                column: "Requirement",
                value: 10000000m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TrainerId",
                table: "BirdTrainingReport",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "MembershipRank",
                keyColumn: "Id",
                keyValue: 2,
                column: "Requirement",
                value: 50000000m);

            migrationBuilder.UpdateData(
                table: "MembershipRank",
                keyColumn: "Id",
                keyValue: 3,
                column: "Requirement",
                value: 100000000m);

            migrationBuilder.CreateIndex(
                name: "IX_BirdTrainingReport_TrainerId",
                table: "BirdTrainingReport",
                column: "TrainerId");

            migrationBuilder.AddForeignKey(
                name: "FK_BirdTrainingReport_Trainer_TrainerId",
                table: "BirdTrainingReport",
                column: "TrainerId",
                principalTable: "Trainer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
