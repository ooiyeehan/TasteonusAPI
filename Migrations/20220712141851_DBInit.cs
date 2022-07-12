using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TasteonusAPI.Migrations
{
    public partial class DBInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "REWARD_T",
                columns: table => new
                {
                    rew_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    rew_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    rew_description = table.Column<string>(type: "varchar(400)", maxLength: 400, nullable: false),
                    rew_point = table.Column<int>(type: "int", nullable: false),
                    rew_imageurl = table.Column<string>(type: "varchar(400)", maxLength: 400, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rewards", x => x.rew_id);
                });

            migrationBuilder.CreateTable(
                name: "USER_T",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    user_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    user_point = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "FEEDBACK_T",
                columns: table => new
                {
                    fb_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    fb_description = table.Column<string>(type: "varchar(400)", maxLength: 400, nullable: false),
                    fb_rating = table.Column<decimal>(type: "decimal(2,1)", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    user_fb = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.fb_id);
                    table.ForeignKey(
                        name: "FK_FEEDBACK_T_USER_T_user_fb",
                        column: x => x.user_fb,
                        principalTable: "USER_T",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RECIPE_T",
                columns: table => new
                {
                    rec_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    rec_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    rec_ingredient = table.Column<string>(type: "longtext", nullable: false),
                    rec_instruction = table.Column<string>(type: "longtext", nullable: false),
                    rec_imageurl = table.Column<string>(type: "varchar(400)", maxLength: 400, nullable: false),
                    rec_videourl = table.Column<string>(type: "varchar(400)", maxLength: 400, nullable: true),
                    rec_rating = table.Column<decimal>(type: "decimal(2,1)", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    user_rec = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.rec_id);
                    table.ForeignKey(
                        name: "FK_RECIPE_T_USER_T_user_rec",
                        column: x => x.user_rec,
                        principalTable: "USER_T",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FEEDBACK_T_user_fb",
                table: "FEEDBACK_T",
                column: "user_fb",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RECIPE_T_user_rec",
                table: "RECIPE_T",
                column: "user_rec",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FEEDBACK_T");

            migrationBuilder.DropTable(
                name: "RECIPE_T");

            migrationBuilder.DropTable(
                name: "REWARD_T");

            migrationBuilder.DropTable(
                name: "USER_T");
        }
    }
}
