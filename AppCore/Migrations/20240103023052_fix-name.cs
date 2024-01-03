using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppCore.Migrations
{
    public partial class fixname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LessionId",
                table: "Customer_LessonDetail",
                newName: "LessonId");

            migrationBuilder.RenameIndex(
                name: "IX_Customer_LessonDetail_LessionId",
                table: "Customer_LessonDetail",
                newName: "IX_Customer_LessonDetail_LessonId");

            migrationBuilder.RenameColumn(
                name: "ShortDescrption",
                table: "Certificate",
                newName: "ShortDescription");

            migrationBuilder.AlterColumn<decimal>(
                name: "PhoneNumber",
                table: "User",
                type: "numeric(18,0)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,0)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "User",
                type: "character varying(100)",
                unicode: false,
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldUnicode: false,
                oldMaxLength: 100,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LessonId",
                table: "Customer_LessonDetail",
                newName: "LessionId");

            migrationBuilder.RenameIndex(
                name: "IX_Customer_LessonDetail_LessonId",
                table: "Customer_LessonDetail",
                newName: "IX_Customer_LessonDetail_LessionId");

            migrationBuilder.RenameColumn(
                name: "ShortDescription",
                table: "Certificate",
                newName: "ShortDescrption");

            migrationBuilder.AlterColumn<decimal>(
                name: "PhoneNumber",
                table: "User",
                type: "numeric(18,0)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,0)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "User",
                type: "character varying(100)",
                unicode: false,
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldUnicode: false,
                oldMaxLength: 100);
        }
    }
}
