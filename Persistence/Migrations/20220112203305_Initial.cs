using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recipe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeeklyMenu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Day = table.Column<string>(type: "text", nullable: true),
                    LunchRecipeId = table.Column<int>(type: "integer", nullable: true),
                    DinnerRecipeId = table.Column<int>(type: "integer", nullable: true),
                    Position = table.Column<int>(type: "integer", nullable: false)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeeklyMenu");

            migrationBuilder.DropTable(
                name: "Recipe");
        }
    }
}
