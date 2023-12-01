using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AppCore.Migrations
{
    public partial class addtrainingcoursecheckoutpolicy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TrainingCourseCheckOutPolicyId",
                table: "Bird_TrainingCourse",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TrainingCourseCheckOutPolicies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ChargeRate = table.Column<float>(type: "real", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingCourseCheckOutPolicies", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bird_TrainingCourse_TrainingCourseCheckOutPolicyId",
                table: "Bird_TrainingCourse",
                column: "TrainingCourseCheckOutPolicyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bird_TrainingCourse_TrainingCourseCheckOutPolicies_Training~",
                table: "Bird_TrainingCourse",
                column: "TrainingCourseCheckOutPolicyId",
                principalTable: "TrainingCourseCheckOutPolicies",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bird_TrainingCourse_TrainingCourseCheckOutPolicies_Training~",
                table: "Bird_TrainingCourse");

            migrationBuilder.DropTable(
                name: "TrainingCourseCheckOutPolicies");

            migrationBuilder.DropIndex(
                name: "IX_Bird_TrainingCourse_TrainingCourseCheckOutPolicyId",
                table: "Bird_TrainingCourse");

            migrationBuilder.DropColumn(
                name: "TrainingCourseCheckOutPolicyId",
                table: "Bird_TrainingCourse");
        }
    }
}
