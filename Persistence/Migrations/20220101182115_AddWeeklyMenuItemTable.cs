using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AddWeeklyMenuItemTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeeklyMenuItem",
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
                    table.PrimaryKey("PK_WeeklyMenuItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeeklyMenuItem_Recipe_DinnerRecipeId",
                        column: x => x.DinnerRecipeId,
                        principalTable: "Recipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WeeklyMenuItem_Recipe_LunchRecipeId",
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
                name: "IX_WeeklyMenuItem_DinnerRecipeId",
                table: "WeeklyMenuItem",
                column: "DinnerRecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyMenuItem_LunchRecipeId",
                table: "WeeklyMenuItem",
                column: "LunchRecipeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeeklyMenuItem");

            migrationBuilder.DropIndex(
                name: "IX_Recipe_Name",
                table: "Recipe");
        }
    }
}
