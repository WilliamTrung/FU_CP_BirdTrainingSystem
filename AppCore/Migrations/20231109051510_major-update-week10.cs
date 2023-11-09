using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AppCore.Migrations
{
    public partial class majorupdateweek10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FKBirdTraini332709",
                table: "BirdTrainingReport");

            migrationBuilder.DropForeignKey(
                name: "FKFeedback625969",
                table: "Feedback");

            migrationBuilder.DropTable(
                name: "FeedbackType");

            migrationBuilder.DropIndex(
                name: "IX_Feedback_FeedbackTypeId",
                table: "Feedback");

            migrationBuilder.DropPrimaryKey(
                name: "PK__BirdCert__CB94077CD6544A76",
                table: "BirdCertificateDetail");

            migrationBuilder.DropColumn(
                name: "DateCreate",
                table: "BirdTrainingReport");

            migrationBuilder.DropColumn(
                name: "StartTrainingDate",
                table: "Bird_TrainingProgress");

            migrationBuilder.DropColumn(
                name: "ActualDateReturn",
                table: "Bird_TrainingCourse");

            migrationBuilder.DropColumn(
                name: "ActualStartDate",
                table: "Bird_TrainingCourse");

            migrationBuilder.DropColumn(
                name: "DateReceivedBird",
                table: "Bird_TrainingCourse");

            migrationBuilder.DropColumn(
                name: "ExpectedDateReturn",
                table: "Bird_TrainingCourse");

            migrationBuilder.DropColumn(
                name: "ExpectedStartDate",
                table: "Bird_TrainingCourse");

            migrationBuilder.DropColumn(
                name: "ExpectedTrainingDoneDate",
                table: "Bird_TrainingCourse");

            migrationBuilder.DropColumn(
                name: "LastestUpdate",
                table: "Bird_TrainingCourse");

            migrationBuilder.RenameColumn(
                name: "FeedbackTypeId",
                table: "Feedback",
                newName: "FeedbackType");

            migrationBuilder.AlterColumn<int>(
                name: "TrainerId",
                table: "TrainerSlot",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Feedback",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "BirdCertificateDetail",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "BirdTrainingCourseId",
                table: "BirdCertificateDetail",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateReceived",
                table: "Bird_TrainingCourse",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateReturn",
                table: "Bird_TrainingCourse",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTrainingDate",
                table: "Bird_TrainingCourse",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BirdCertificateDetail",
                table: "BirdCertificateDetail",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "BirdSkillReceived",
                columns: table => new
                {
                    BirdSkillId = table.Column<int>(type: "integer", nullable: false),
                    BirdId = table.Column<int>(type: "integer", nullable: false),
                    ReceivedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BirdSkillReceived", x => new { x.BirdSkillId, x.BirdId });
                    table.ForeignKey(
                        name: "FK_BirdSkillReceived_Bird_BirdId",
                        column: x => x.BirdId,
                        principalTable: "Bird",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BirdSkillReceived_BirdSkill_BirdSkillId",
                        column: x => x.BirdSkillId,
                        principalTable: "BirdSkill",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BirdCertificateDetail_BirdId",
                table: "BirdCertificateDetail",
                column: "BirdId");

            migrationBuilder.CreateIndex(
                name: "IX_BirdCertificateDetail_BirdTrainingCourseId",
                table: "BirdCertificateDetail",
                column: "BirdTrainingCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_BirdSkillReceived_BirdId",
                table: "BirdSkillReceived",
                column: "BirdId");

            migrationBuilder.AddForeignKey(
                name: "FK_BirdCertificateDetail_Bird_TrainingCourse_BirdTrainingCours~",
                table: "BirdCertificateDetail",
                column: "BirdTrainingCourseId",
                principalTable: "Bird_TrainingCourse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BirdTrainingReport_Trainer_TrainerId",
                table: "BirdTrainingReport",
                column: "TrainerId",
                principalTable: "Trainer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BirdCertificateDetail_Bird_TrainingCourse_BirdTrainingCours~",
                table: "BirdCertificateDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_BirdTrainingReport_Trainer_TrainerId",
                table: "BirdTrainingReport");

            migrationBuilder.DropTable(
                name: "BirdSkillReceived");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BirdCertificateDetail",
                table: "BirdCertificateDetail");

            migrationBuilder.DropIndex(
                name: "IX_BirdCertificateDetail_BirdId",
                table: "BirdCertificateDetail");

            migrationBuilder.DropIndex(
                name: "IX_BirdCertificateDetail_BirdTrainingCourseId",
                table: "BirdCertificateDetail");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Feedback");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "BirdCertificateDetail");

            migrationBuilder.DropColumn(
                name: "BirdTrainingCourseId",
                table: "BirdCertificateDetail");

            migrationBuilder.DropColumn(
                name: "DateReceived",
                table: "Bird_TrainingCourse");

            migrationBuilder.DropColumn(
                name: "DateReturn",
                table: "Bird_TrainingCourse");

            migrationBuilder.DropColumn(
                name: "StartTrainingDate",
                table: "Bird_TrainingCourse");

            migrationBuilder.RenameColumn(
                name: "FeedbackType",
                table: "Feedback",
                newName: "FeedbackTypeId");

            migrationBuilder.AlterColumn<int>(
                name: "TrainerId",
                table: "TrainerSlot",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreate",
                table: "BirdTrainingReport",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTrainingDate",
                table: "Bird_TrainingProgress",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ActualDateReturn",
                table: "Bird_TrainingCourse",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ActualStartDate",
                table: "Bird_TrainingCourse",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateReceivedBird",
                table: "Bird_TrainingCourse",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpectedDateReturn",
                table: "Bird_TrainingCourse",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpectedStartDate",
                table: "Bird_TrainingCourse",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpectedTrainingDoneDate",
                table: "Bird_TrainingCourse",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastestUpdate",
                table: "Bird_TrainingCourse",
                type: "date",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK__BirdCert__CB94077CD6544A76",
                table: "BirdCertificateDetail",
                columns: new[] { "BirdId", "BirdCertificateId" });

            migrationBuilder.CreateTable(
                name: "FeedbackType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedbackType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_FeedbackTypeId",
                table: "Feedback",
                column: "FeedbackTypeId");

            migrationBuilder.AddForeignKey(
                name: "FKBirdTraini332709",
                table: "BirdTrainingReport",
                column: "TrainerId",
                principalTable: "Trainer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FKFeedback625969",
                table: "Feedback",
                column: "FeedbackTypeId",
                principalTable: "FeedbackType",
                principalColumn: "Id");
        }
    }
}
