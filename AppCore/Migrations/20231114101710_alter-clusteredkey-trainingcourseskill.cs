using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppCore.Migrations
{
    public partial class alterclusteredkeytrainingcourseskill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FKBird_Train174512",
                table: "Bird_TrainingProgress");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_TrainingCourseSkill_TempId",
                table: "TrainingCourseSkill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainingCourseSkill",
                table: "TrainingCourseSkill");

            migrationBuilder.DropColumn(
                name: "TempId",
                table: "TrainingCourseSkill");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Training__1D80EC183F24C734",
                table: "TrainingCourseSkill",
                column: "BirdSkillId");

            migrationBuilder.AddForeignKey(
                name: "FKBird_Train174512",
                table: "Bird_TrainingProgress",
                column: "TrainingCourse_SkillId",
                principalTable: "TrainingCourseSkill",
                principalColumn: "BirdSkillId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FKBird_Train174512",
                table: "Bird_TrainingProgress");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Training__1D80EC183F24C734",
                table: "TrainingCourseSkill");

            migrationBuilder.AddColumn<int>(
                name: "TempId",
                table: "TrainingCourseSkill",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_TrainingCourseSkill_TempId",
                table: "TrainingCourseSkill",
                column: "TempId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainingCourseSkill",
                table: "TrainingCourseSkill",
                columns: new[] { "BirdSkillId", "TrainingCourseId" });

            migrationBuilder.AddForeignKey(
                name: "FKBird_Train174512",
                table: "Bird_TrainingProgress",
                column: "TrainingCourse_SkillId",
                principalTable: "TrainingCourseSkill",
                principalColumn: "TempId");
        }
    }
}
