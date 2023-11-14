using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppCore.Migrations
{
    public partial class addbirdspecies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BirdSpecies",
                columns: new[] { "Id", "Name", "ShortDetail" },
                values: new object[,]
                {
                    { 1, "Parakeet", "Small, colorful parakeets known for their friendly and social nature." },
                    { 2, "Cockatiel", "Medium-sized parrots that are easy to tame and often enjoy human interaction." },
                    { 3, "Canary", "Small songbirds known for their melodious singing." },
                    { 4, "Lovebird", "Small parrots that are highly social and form strong bonds with their owners." },
                    { 5, "Cockatoo", "Large parrots known for their playful and affectionate personalities." },
                    { 6, "Finch", "Small, active birds typically kept in aviaries or spacious cages." },
                    { 7, "Canary-winged Parakeet", "Docile parakeets that are often considered good pets." },
                    { 8, "Parrotlet", "Tiny parrots with big personalities, known for their inquisitive and playful behavior." },
                    { 9, "Budgerigar (Budgie)", "Small parakeets that make excellent in-home pets, easy to care for and enjoy human interaction." },
                    { 10, "Quaker Parrot (Monk Parakeet)", "Medium-sized parrots known for their social nature and ability to mimic words." }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BirdSpecies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BirdSpecies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BirdSpecies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BirdSpecies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BirdSpecies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "BirdSpecies",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "BirdSpecies",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "BirdSpecies",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "BirdSpecies",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "BirdSpecies",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
