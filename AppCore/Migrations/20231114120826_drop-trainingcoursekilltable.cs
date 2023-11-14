using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppCore.Migrations
{
    public partial class droptrainingcoursekilltable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FKBird_Train174512",
                table: "Bird_TrainingProgress");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingCourseSkillDetail_BirdSkill_BirdSkillId",
                table: "TrainingCourseSkillDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingCourseSkillDetail_TrainingCourse_TrainingCourseId",
                table: "TrainingCourseSkillDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainingCourseSkillDetail",
                table: "TrainingCourseSkillDetail");

            migrationBuilder.RenameTable(
                name: "TrainingCourseSkillDetail",
                newName: "TrainingCourseSkill");

            migrationBuilder.RenameColumn(
                name: "TrainingCourse_SkillId",
                table: "Bird_TrainingProgress",
                newName: "TrainingCourseSkillId");

            migrationBuilder.RenameIndex(
                name: "IX_Bird_TrainingProgress_TrainingCourse_SkillId",
                table: "Bird_TrainingProgress",
                newName: "IX_Bird_TrainingProgress_TrainingCourseSkillId");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingCourseSkillDetail_TrainingCourseId",
                table: "TrainingCourseSkill",
                newName: "IX_TrainingCourseSkill_TrainingCourseId");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingCourseSkillDetail_BirdSkillId",
                table: "TrainingCourseSkill",
                newName: "IX_TrainingCourseSkill_BirdSkillId");

            migrationBuilder.AlterColumn<int>(
                name: "TrainingCourseSkillId",
                table: "Bird_TrainingProgress",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainingCourseSkill",
                table: "TrainingCourseSkill",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bird_TrainingProgress_TrainingCourseSkill_TrainingCourseSki~",
                table: "Bird_TrainingProgress",
                column: "TrainingCourseSkillId",
                principalTable: "TrainingCourseSkill",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingCourseSkill_BirdSkill_BirdSkillId",
                table: "TrainingCourseSkill",
                column: "BirdSkillId",
                principalTable: "BirdSkill",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingCourseSkill_TrainingCourse_TrainingCourseId",
                table: "TrainingCourseSkill",
                column: "TrainingCourseId",
                principalTable: "TrainingCourse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bird_TrainingProgress_TrainingCourseSkill_TrainingCourseSki~",
                table: "Bird_TrainingProgress");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingCourseSkill_BirdSkill_BirdSkillId",
                table: "TrainingCourseSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingCourseSkill_TrainingCourse_TrainingCourseId",
                table: "TrainingCourseSkill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainingCourseSkill",
                table: "TrainingCourseSkill");

            migrationBuilder.RenameTable(
                name: "TrainingCourseSkill",
                newName: "TrainingCourseSkillDetail");

            migrationBuilder.RenameColumn(
                name: "TrainingCourseSkillId",
                table: "Bird_TrainingProgress",
                newName: "TrainingCourse_SkillId");

            migrationBuilder.RenameIndex(
                name: "IX_Bird_TrainingProgress_TrainingCourseSkillId",
                table: "Bird_TrainingProgress",
                newName: "IX_Bird_TrainingProgress_TrainingCourse_SkillId");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingCourseSkill_TrainingCourseId",
                table: "TrainingCourseSkillDetail",
                newName: "IX_TrainingCourseSkillDetail_TrainingCourseId");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingCourseSkill_BirdSkillId",
                table: "TrainingCourseSkillDetail",
                newName: "IX_TrainingCourseSkillDetail_BirdSkillId");

            migrationBuilder.AlterColumn<int>(
                name: "TrainingCourse_SkillId",
                table: "Bird_TrainingProgress",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainingCourseSkillDetail",
                table: "TrainingCourseSkillDetail",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FKBird_Train174512",
                table: "Bird_TrainingProgress",
                column: "TrainingCourse_SkillId",
                principalTable: "TrainingCourseSkillDetail",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingCourseSkillDetail_BirdSkill_BirdSkillId",
                table: "TrainingCourseSkillDetail",
                column: "BirdSkillId",
                principalTable: "BirdSkill",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingCourseSkillDetail_TrainingCourse_TrainingCourseId",
                table: "TrainingCourseSkillDetail",
                column: "TrainingCourseId",
                principalTable: "TrainingCourse",
                principalColumn: "Id");
        }
    }
}
