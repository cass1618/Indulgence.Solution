using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Park.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cocktails",
                columns: table => new
                {
                    CocktailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DrinkName = table.Column<string>(type: "varchar(50) CHARACTER SET utf8mb4", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cocktails", x => x.CocktailId);
                });

            migrationBuilder.CreateTable(
                name: "Steps",
                columns: table => new
                {
                    StepId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StepName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    StepType = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Steps", x => x.StepId);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    IngredientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IngredientName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    IngredientType = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    CocktailId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.IngredientId);
                    table.ForeignKey(
                        name: "FK_Ingredients_Cocktails_CocktailId",
                        column: x => x.CocktailId,
                        principalTable: "Cocktails",
                        principalColumn: "CocktailId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CocktailStep",
                columns: table => new
                {
                    CocktailStepId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StepId = table.Column<int>(type: "int", nullable: false),
                    CocktailId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CocktailStep", x => x.CocktailStepId);
                    table.ForeignKey(
                        name: "FK_CocktailStep_Cocktails_CocktailId",
                        column: x => x.CocktailId,
                        principalTable: "Cocktails",
                        principalColumn: "CocktailId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CocktailStep_Steps_StepId",
                        column: x => x.StepId,
                        principalTable: "Steps",
                        principalColumn: "StepId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CocktailIngredient",
                columns: table => new
                {
                    CocktailIngredientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IngredientId = table.Column<int>(type: "int", nullable: false),
                    CocktailId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CocktailIngredient", x => x.CocktailIngredientId);
                    table.ForeignKey(
                        name: "FK_CocktailIngredient_Cocktails_CocktailId",
                        column: x => x.CocktailId,
                        principalTable: "Cocktails",
                        principalColumn: "CocktailId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CocktailIngredient_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "IngredientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CocktailIngredient_CocktailId",
                table: "CocktailIngredient",
                column: "CocktailId");

            migrationBuilder.CreateIndex(
                name: "IX_CocktailIngredient_IngredientId",
                table: "CocktailIngredient",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_CocktailStep_CocktailId",
                table: "CocktailStep",
                column: "CocktailId");

            migrationBuilder.CreateIndex(
                name: "IX_CocktailStep_StepId",
                table: "CocktailStep",
                column: "StepId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_CocktailId",
                table: "Ingredients",
                column: "CocktailId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CocktailIngredient");

            migrationBuilder.DropTable(
                name: "CocktailStep");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Steps");

            migrationBuilder.DropTable(
                name: "Cocktails");
        }
    }
}
