using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppCore.Migrations
{
    public partial class removefeedbacktypetb_feedback : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FeedbackType",
                table: "Feedback");

            migrationBuilder.DropColumn(
                name: "Adddress",
                table: "ConsultingTicket");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FeedbackType",
                table: "Feedback",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Adddress",
                table: "ConsultingTicket",
                type: "text",
                nullable: true);
        }
    }
}
