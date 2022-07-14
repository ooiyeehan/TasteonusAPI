using Microsoft.EntityFrameworkCore.Migrations;

namespace TasteonusAPI.Migrations
{
    public partial class DBInit5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "user_uid",
                table: "USER_T",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "user_uid",
                table: "USER_T");
        }
    }
}
