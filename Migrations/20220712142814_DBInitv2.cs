using Microsoft.EntityFrameworkCore.Migrations;

namespace TasteonusAPI.Migrations
{
    public partial class DBInitv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FEEDBACK_T_USER_T_user_fb",
                table: "FEEDBACK_T");

            migrationBuilder.DropForeignKey(
                name: "FK_RECIPE_T_USER_T_user_rec",
                table: "RECIPE_T");

            migrationBuilder.DropIndex(
                name: "IX_RECIPE_T_user_rec",
                table: "RECIPE_T");

            migrationBuilder.DropIndex(
                name: "IX_FEEDBACK_T_user_fb",
                table: "FEEDBACK_T");

            migrationBuilder.DropColumn(
                name: "user_rec",
                table: "RECIPE_T");

            migrationBuilder.DropColumn(
                name: "user_fb",
                table: "FEEDBACK_T");

            migrationBuilder.CreateIndex(
                name: "IX_RECIPE_T_user_id",
                table: "RECIPE_T",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FEEDBACK_T_user_id",
                table: "FEEDBACK_T",
                column: "user_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FEEDBACK_T_USER_T_user_id",
                table: "FEEDBACK_T",
                column: "user_id",
                principalTable: "USER_T",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RECIPE_T_USER_T_user_id",
                table: "RECIPE_T",
                column: "user_id",
                principalTable: "USER_T",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FEEDBACK_T_USER_T_user_id",
                table: "FEEDBACK_T");

            migrationBuilder.DropForeignKey(
                name: "FK_RECIPE_T_USER_T_user_id",
                table: "RECIPE_T");

            migrationBuilder.DropIndex(
                name: "IX_RECIPE_T_user_id",
                table: "RECIPE_T");

            migrationBuilder.DropIndex(
                name: "IX_FEEDBACK_T_user_id",
                table: "FEEDBACK_T");

            migrationBuilder.AddColumn<int>(
                name: "user_rec",
                table: "RECIPE_T",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "user_fb",
                table: "FEEDBACK_T",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RECIPE_T_user_rec",
                table: "RECIPE_T",
                column: "user_rec",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FEEDBACK_T_user_fb",
                table: "FEEDBACK_T",
                column: "user_fb",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FEEDBACK_T_USER_T_user_fb",
                table: "FEEDBACK_T",
                column: "user_fb",
                principalTable: "USER_T",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RECIPE_T_USER_T_user_rec",
                table: "RECIPE_T",
                column: "user_rec",
                principalTable: "USER_T",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
