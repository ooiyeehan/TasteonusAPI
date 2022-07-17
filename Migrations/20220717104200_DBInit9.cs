using Microsoft.EntityFrameworkCore.Migrations;

namespace TasteonusAPI.Migrations
{
    public partial class DBInit9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "rec_rating",
                table: "RECIPE_T");

            migrationBuilder.AddColumn<int>(
                name: "rec_id",
                table: "FEEDBACK_T",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FEEDBACK_T_rec_id",
                table: "FEEDBACK_T",
                column: "rec_id");

            migrationBuilder.AddForeignKey(
                name: "FK_FEEDBACK_T_RECIPE_T_rec_id",
                table: "FEEDBACK_T",
                column: "rec_id",
                principalTable: "RECIPE_T",
                principalColumn: "rec_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FEEDBACK_T_RECIPE_T_rec_id",
                table: "FEEDBACK_T");

            migrationBuilder.DropIndex(
                name: "IX_FEEDBACK_T_rec_id",
                table: "FEEDBACK_T");

            migrationBuilder.DropColumn(
                name: "rec_id",
                table: "FEEDBACK_T");

            migrationBuilder.AddColumn<decimal>(
                name: "rec_rating",
                table: "RECIPE_T",
                type: "decimal(2,1)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
