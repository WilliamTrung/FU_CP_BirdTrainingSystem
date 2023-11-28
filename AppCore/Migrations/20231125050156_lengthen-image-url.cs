using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppCore.Migrations
{
    public partial class lengthenimageurl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Picture",
                table: "Workshop",
                type: "character varying(512)",
                unicode: false,
                maxLength: 512,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldUnicode: false,
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "User",
                type: "character varying(512)",
                unicode: false,
                maxLength: 512,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldUnicode: false,
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Avatar",
                table: "User",
                type: "character varying(512)",
                unicode: false,
                maxLength: 512,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldUnicode: false,
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Picture",
                table: "TrainingCourse",
                type: "character varying(512)",
                unicode: false,
                maxLength: 512,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldUnicode: false,
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Picture",
                table: "OnlineCourse",
                type: "character varying(512)",
                unicode: false,
                maxLength: 512,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldUnicode: false,
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Video",
                table: "Lesson",
                type: "character varying(512)",
                unicode: false,
                maxLength: 512,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldUnicode: false,
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GgMeetLink",
                table: "ConsultingTicket",
                type: "character varying(512)",
                unicode: false,
                maxLength: 512,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldUnicode: false,
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Evidence",
                table: "ConsultingTicket",
                type: "character varying(512)",
                unicode: false,
                maxLength: 512,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldUnicode: false,
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Picture",
                table: "Certificate",
                type: "character varying(512)",
                unicode: false,
                maxLength: 512,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldUnicode: false,
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Evidence",
                table: "BirdTrainingReport",
                type: "character varying(512)",
                unicode: false,
                maxLength: 512,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldUnicode: false,
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Picture",
                table: "BirdCertificate",
                type: "character varying(512)",
                unicode: false,
                maxLength: 512,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldUnicode: false,
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Evidence",
                table: "Bird_TrainingProgress",
                type: "character varying(512)",
                unicode: false,
                maxLength: 512,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldUnicode: false,
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReturnPicture",
                table: "Bird_TrainingCourse",
                type: "character varying(512)",
                unicode: false,
                maxLength: 512,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldUnicode: false,
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReturnNote",
                table: "Bird_TrainingCourse",
                type: "character varying(512)",
                unicode: false,
                maxLength: 512,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldUnicode: false,
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReceivePicture",
                table: "Bird_TrainingCourse",
                type: "character varying(512)",
                unicode: false,
                maxLength: 512,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldUnicode: false,
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReceiveNote",
                table: "Bird_TrainingCourse",
                type: "character varying(512)",
                unicode: false,
                maxLength: 512,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldUnicode: false,
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Picture",
                table: "Bird",
                type: "character varying(512)",
                unicode: false,
                maxLength: 512,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldUnicode: false,
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Bird",
                type: "character varying(512)",
                unicode: false,
                maxLength: 512,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldUnicode: false,
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AddressDetail",
                table: "Address",
                type: "character varying(512)",
                unicode: false,
                maxLength: 512,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldUnicode: false,
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Condition",
                table: "AcquirableSkill",
                type: "character varying(512)",
                unicode: false,
                maxLength: 512,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldUnicode: false,
                oldMaxLength: 255,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Picture",
                table: "Workshop",
                type: "character varying(255)",
                unicode: false,
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(512)",
                oldUnicode: false,
                oldMaxLength: 512,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "User",
                type: "character varying(255)",
                unicode: false,
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(512)",
                oldUnicode: false,
                oldMaxLength: 512);

            migrationBuilder.AlterColumn<string>(
                name: "Avatar",
                table: "User",
                type: "character varying(255)",
                unicode: false,
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(512)",
                oldUnicode: false,
                oldMaxLength: 512,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Picture",
                table: "TrainingCourse",
                type: "character varying(255)",
                unicode: false,
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(512)",
                oldUnicode: false,
                oldMaxLength: 512,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Picture",
                table: "OnlineCourse",
                type: "character varying(255)",
                unicode: false,
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(512)",
                oldUnicode: false,
                oldMaxLength: 512,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Video",
                table: "Lesson",
                type: "character varying(255)",
                unicode: false,
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(512)",
                oldUnicode: false,
                oldMaxLength: 512,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GgMeetLink",
                table: "ConsultingTicket",
                type: "character varying(255)",
                unicode: false,
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(512)",
                oldUnicode: false,
                oldMaxLength: 512,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Evidence",
                table: "ConsultingTicket",
                type: "character varying(255)",
                unicode: false,
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(512)",
                oldUnicode: false,
                oldMaxLength: 512,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Picture",
                table: "Certificate",
                type: "character varying(255)",
                unicode: false,
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(512)",
                oldUnicode: false,
                oldMaxLength: 512,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Evidence",
                table: "BirdTrainingReport",
                type: "character varying(255)",
                unicode: false,
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(512)",
                oldUnicode: false,
                oldMaxLength: 512,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Picture",
                table: "BirdCertificate",
                type: "character varying(255)",
                unicode: false,
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(512)",
                oldUnicode: false,
                oldMaxLength: 512,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Evidence",
                table: "Bird_TrainingProgress",
                type: "character varying(255)",
                unicode: false,
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(512)",
                oldUnicode: false,
                oldMaxLength: 512,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReturnPicture",
                table: "Bird_TrainingCourse",
                type: "character varying(255)",
                unicode: false,
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(512)",
                oldUnicode: false,
                oldMaxLength: 512,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReturnNote",
                table: "Bird_TrainingCourse",
                type: "character varying(255)",
                unicode: false,
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(512)",
                oldUnicode: false,
                oldMaxLength: 512,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReceivePicture",
                table: "Bird_TrainingCourse",
                type: "character varying(255)",
                unicode: false,
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(512)",
                oldUnicode: false,
                oldMaxLength: 512,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReceiveNote",
                table: "Bird_TrainingCourse",
                type: "character varying(255)",
                unicode: false,
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(512)",
                oldUnicode: false,
                oldMaxLength: 512,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Picture",
                table: "Bird",
                type: "character varying(255)",
                unicode: false,
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(512)",
                oldUnicode: false,
                oldMaxLength: 512,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Bird",
                type: "character varying(255)",
                unicode: false,
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(512)",
                oldUnicode: false,
                oldMaxLength: 512,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AddressDetail",
                table: "Address",
                type: "character varying(255)",
                unicode: false,
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(512)",
                oldUnicode: false,
                oldMaxLength: 512);

            migrationBuilder.AlterColumn<string>(
                name: "Condition",
                table: "AcquirableSkill",
                type: "character varying(255)",
                unicode: false,
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(512)",
                oldUnicode: false,
                oldMaxLength: 512,
                oldNullable: true);
        }
    }
}
