using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantAPI.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddDishIngredientTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DishIngredient_Dishes_DishId",
                table: "DishIngredient");

            migrationBuilder.DropForeignKey(
                name: "FK_DishIngredient_Ingredients_IngredientId",
                table: "DishIngredient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DishIngredient",
                table: "DishIngredient");

            migrationBuilder.RenameTable(
                name: "DishIngredient",
                newName: "DishIngredients");

            migrationBuilder.RenameIndex(
                name: "IX_DishIngredient_IngredientId",
                table: "DishIngredients",
                newName: "IX_DishIngredients_IngredientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DishIngredients",
                table: "DishIngredients",
                columns: new[] { "DishId", "IngredientId" });

            migrationBuilder.AddForeignKey(
                name: "FK_DishIngredients_Dishes_DishId",
                table: "DishIngredients",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DishIngredients_Ingredients_IngredientId",
                table: "DishIngredients",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DishIngredients_Dishes_DishId",
                table: "DishIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_DishIngredients_Ingredients_IngredientId",
                table: "DishIngredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DishIngredients",
                table: "DishIngredients");

            migrationBuilder.RenameTable(
                name: "DishIngredients",
                newName: "DishIngredient");

            migrationBuilder.RenameIndex(
                name: "IX_DishIngredients_IngredientId",
                table: "DishIngredient",
                newName: "IX_DishIngredient_IngredientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DishIngredient",
                table: "DishIngredient",
                columns: new[] { "DishId", "IngredientId" });

            migrationBuilder.AddForeignKey(
                name: "FK_DishIngredient_Dishes_DishId",
                table: "DishIngredient",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DishIngredient_Ingredients_IngredientId",
                table: "DishIngredient",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
