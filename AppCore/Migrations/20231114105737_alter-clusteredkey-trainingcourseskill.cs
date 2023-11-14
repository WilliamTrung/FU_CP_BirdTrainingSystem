using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppCore.Migrations
{
    public partial class alterclusteredkeytrainingcourseskill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FKTrainingCo551235",
                table: "TrainingCourseSkill");

            migrationBuilder.DropForeignKey(
                name: "FKTrainingCo866476",
                table: "TrainingCourseSkill");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingCourseSkill_BirdSkill_BirdSkillId",
                table: "TrainingCourseSkill",
                column: "BirdSkillId",
                principalTable: "BirdSkill",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingCourseSkill_TrainingCourse_TrainingCourseId",
                table: "TrainingCourseSkill",
                column: "TrainingCourseId",
                principalTable: "TrainingCourse",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingCourseSkill_BirdSkill_BirdSkillId",
                table: "TrainingCourseSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingCourseSkill_TrainingCourse_TrainingCourseId",
                table: "TrainingCourseSkill");

            migrationBuilder.AddForeignKey(
                name: "FKTrainingCo551235",
                table: "TrainingCourseSkill",
                column: "BirdSkillId",
                principalTable: "BirdSkill",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FKTrainingCo866476",
                table: "TrainingCourseSkill",
                column: "TrainingCourseId",
                principalTable: "TrainingCourse",
                principalColumn: "Id");
        }
    }
}
