using Microsoft.EntityFrameworkCore.Migrations;

namespace TasteonusAPI.Migrations
{
    public partial class DBInit3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "user_biodata",
                table: "USER_T",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "user_email",
                table: "USER_T",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "user_imageurl",
                table: "USER_T",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "user_password",
                table: "USER_T",
                type: "varchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "user_biodata",
                table: "USER_T");

            migrationBuilder.DropColumn(
                name: "user_email",
                table: "USER_T");

            migrationBuilder.DropColumn(
                name: "user_imageurl",
                table: "USER_T");

            migrationBuilder.DropColumn(
                name: "user_password",
                table: "USER_T");
        }
    }
}
