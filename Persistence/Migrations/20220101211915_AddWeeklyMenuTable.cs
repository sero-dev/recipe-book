using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AddWeeklyMenuTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeeklyMenu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Day = table.Column<string>(type: "TEXT", nullable: true),
                    LunchRecipeId = table.Column<int>(type: "INTEGER", nullable: true),
                    DinnerRecipeId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeeklyMenu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeeklyMenu_Recipe_DinnerRecipeId",
                        column: x => x.DinnerRecipeId,
                        principalTable: "Recipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WeeklyMenu_Recipe_LunchRecipeId",
                        column: x => x.LunchRecipeId,
                        principalTable: "Recipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_Name",
                table: "Recipe",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyMenu_DinnerRecipeId",
                table: "WeeklyMenu",
                column: "DinnerRecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyMenu_LunchRecipeId",
                table: "WeeklyMenu",
                column: "LunchRecipeId");


            migrationBuilder.InsertData(table: "WeeklyMenu", columns: new[] { "Id", "Day" }, values: new object[] { 1, "Monday" });
            migrationBuilder.InsertData(table: "WeeklyMenu", columns: new[] { "Id", "Day" }, values: new object[] { 2, "Tuesday" });
            migrationBuilder.InsertData(table: "WeeklyMenu", columns: new[] { "Id", "Day" }, values: new object[] { 3, "Wednesday" });
            migrationBuilder.InsertData(table: "WeeklyMenu", columns: new[] { "Id", "Day" }, values: new object[] { 4, "Thursday" });
            migrationBuilder.InsertData(table: "WeeklyMenu", columns: new[] { "Id", "Day" }, values: new object[] { 5, "Friday" });
            migrationBuilder.InsertData(table: "WeeklyMenu", columns: new[] { "Id", "Day" }, values: new object[] { 6, "Saturday" });
            migrationBuilder.InsertData(table: "WeeklyMenu", columns: new[] { "Id", "Day" }, values: new object[] { 7, "Sunday" });

            migrationBuilder.InsertData(table: "Recipe", columns: new[] { "Id", "Name" }, values: new object[] { 1, "Aloo Chaat" });
            migrationBuilder.InsertData(table: "Recipe", columns: new[] { "Id", "Name" }, values: new object[] { 2, "Biryani" });
            migrationBuilder.InsertData(table: "Recipe", columns: new[] { "Id", "Name" }, values: new object[] { 3, "Braided Salmon" });
            migrationBuilder.InsertData(table: "Recipe", columns: new[] { "Id", "Name" }, values: new object[] { 4, "Buffalo Dip" });
            migrationBuilder.InsertData(table: "Recipe", columns: new[] { "Id", "Name" }, values: new object[] { 5, "Chicken Alfredo" });
            migrationBuilder.InsertData(table: "Recipe", columns: new[] { "Id", "Name" }, values: new object[] { 6, "Chicken Fried Rice" });
            migrationBuilder.InsertData(table: "Recipe", columns: new[] { "Id", "Name" }, values: new object[] { 7, "Cous-Cous" });
            migrationBuilder.InsertData(table: "Recipe", columns: new[] { "Id", "Name" }, values: new object[] { 8, "Flat Bread" });
            migrationBuilder.InsertData(table: "Recipe", columns: new[] { "Id", "Name" }, values: new object[] { 9, "Fried Rice" });
            migrationBuilder.InsertData(table: "Recipe", columns: new[] { "Id", "Name" }, values: new object[] { 10, "Ground Turkey" });
            migrationBuilder.InsertData(table: "Recipe", columns: new[] { "Id", "Name" }, values: new object[] { 11, "Hawaiian Rolls" });
            migrationBuilder.InsertData(table: "Recipe", columns: new[] { "Id", "Name" }, values: new object[] { 12, "Homemade Pasta Sauce" });
            migrationBuilder.InsertData(table: "Recipe", columns: new[] { "Id", "Name" }, values: new object[] { 13, "Impossible Burger" });
            migrationBuilder.InsertData(table: "Recipe", columns: new[] { "Id", "Name" }, values: new object[] { 14, "Jerk Chicken" });
            migrationBuilder.InsertData(table: "Recipe", columns: new[] { "Id", "Name" }, values: new object[] { 15, "Keto Soup" });
            migrationBuilder.InsertData(table: "Recipe", columns: new[] { "Id", "Name" }, values: new object[] { 16, "Macadamia Fish" });
            migrationBuilder.InsertData(table: "Recipe", columns: new[] { "Id", "Name" }, values: new object[] { 17, "Mashed Potatoes" });
            migrationBuilder.InsertData(table: "Recipe", columns: new[] { "Id", "Name" }, values: new object[] { 18, "Morning Star Salad" });
            migrationBuilder.InsertData(table: "Recipe", columns: new[] { "Id", "Name" }, values: new object[] { 19, "Nihari" });
            migrationBuilder.InsertData(table: "Recipe", columns: new[] { "Id", "Name" }, values: new object[] { 20, "Orzo" });
            migrationBuilder.InsertData(table: "Recipe", columns: new[] { "Id", "Name" }, values: new object[] { 21, "Pani Puri" });
            migrationBuilder.InsertData(table: "Recipe", columns: new[] { "Id", "Name" }, values: new object[] { 22, "Rice & Beans" });
            migrationBuilder.InsertData(table: "Recipe", columns: new[] { "Id", "Name" }, values: new object[] { 23, "Samosas" });
            migrationBuilder.InsertData(table: "Recipe", columns: new[] { "Id", "Name" }, values: new object[] { 24, "Shrimp Fried Rice" });
            migrationBuilder.InsertData(table: "Recipe", columns: new[] { "Id", "Name" }, values: new object[] { 25, "Stuffed Mushrooms" });
            migrationBuilder.InsertData(table: "Recipe", columns: new[] { "Id", "Name" }, values: new object[] { 26, "Sukhi's Chicken Tika Masala" });
            migrationBuilder.InsertData(table: "Recipe", columns: new[] { "Id", "Name" }, values: new object[] { 27, "Tandoori Wings" });
            migrationBuilder.InsertData(table: "Recipe", columns: new[] { "Id", "Name" }, values: new object[] { 28, "Trader Joe's Clam Chowder" });
            migrationBuilder.InsertData(table: "Recipe", columns: new[] { "Id", "Name" }, values: new object[] { 29, "Trader Joe's Fiery Chicken" });
            migrationBuilder.InsertData(table: "Recipe", columns: new[] { "Id", "Name" }, values: new object[] { 30, "Trader Joe's Palak Paneer" });
            migrationBuilder.InsertData(table: "Recipe", columns: new[] { "Id", "Name" }, values: new object[] { 31, "Tuna Salad" });
            migrationBuilder.InsertData(table: "Recipe", columns: new[] { "Id", "Name" }, values: new object[] { 32, "Tuscan Chicken" });
            migrationBuilder.InsertData(table: "Recipe", columns: new[] { "Id", "Name" }, values: new object[] { 33, "Tyson Chicken Burger" });
            migrationBuilder.InsertData(table: "Recipe", columns: new[] { "Id", "Name" }, values: new object[] { 34, "Vietnamese Summer Rolls" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeeklyMenu");

            migrationBuilder.DropIndex(
                name: "IX_Recipe_Name",
                table: "Recipe");
        }
    }
}
