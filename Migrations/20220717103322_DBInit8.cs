using Microsoft.EntityFrameworkCore.Migrations;

namespace TasteonusAPI.Migrations
{
    public partial class DBInit8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateIndex(
                name: "IX_FEEDBACK_T_user_id",
                table: "FEEDBACK_T",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateIndex(
                name: "IX_FEEDBACK_T_user_id",
                table: "FEEDBACK_T",
                column: "user_id",
                unique: true);
        }
    }
}
