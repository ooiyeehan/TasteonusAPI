using Microsoft.EntityFrameworkCore.Migrations;

namespace TasteonusAPI.Migrations
{
    public partial class DBInit6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateIndex(
                name: "IX_RECIPE_T_user_id",
                table: "RECIPE_T",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateIndex(
                name: "IX_RECIPE_T_user_id",
                table: "RECIPE_T",
                column: "user_id",
                unique: true);
        }
    }
}
