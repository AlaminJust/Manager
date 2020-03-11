using Microsoft.EntityFrameworkCore.Migrations;

namespace LocalMealManagement.Migrations
{
    public partial class AddingFKSubgroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "subGroups",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_subGroups_IdentityUserId",
                table: "subGroups",
                column: "IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_subGroups_AspNetUsers_IdentityUserId",
                table: "subGroups",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_subGroups_AspNetUsers_IdentityUserId",
                table: "subGroups");

            migrationBuilder.DropIndex(
                name: "IX_subGroups_IdentityUserId",
                table: "subGroups");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "subGroups");
        }
    }
}
