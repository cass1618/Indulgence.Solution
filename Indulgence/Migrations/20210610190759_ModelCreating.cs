using Microsoft.EntityFrameworkCore.Migrations;

namespace Park.Migrations
{
    public partial class ModelCreating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cocktails",
                columns: new[] { "CocktailId", "DrinkName" },
                values: new object[] { 1, "James Bond Vesper" });

            migrationBuilder.InsertData(
                table: "Cocktails",
                columns: new[] { "CocktailId", "DrinkName" },
                values: new object[] { 2, "Black Manhattan" });

            migrationBuilder.InsertData(
                table: "Cocktails",
                columns: new[] { "CocktailId", "DrinkName" },
                values: new object[] { 3, "White Gummy Bear" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "CocktailId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "CocktailId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "CocktailId",
                keyValue: 3);
        }
    }
}
