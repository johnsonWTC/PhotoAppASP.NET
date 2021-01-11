using Microsoft.EntityFrameworkCore.Migrations;

namespace PhotoApp.Migrations
{
    public partial class FollowTableNavigatiom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FollowingUserName",
                table: "Follows",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "followedUserEmail",
                table: "Follows",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FollowingUserName",
                table: "Follows");

            migrationBuilder.DropColumn(
                name: "followedUserEmail",
                table: "Follows");
        }
    }
}
