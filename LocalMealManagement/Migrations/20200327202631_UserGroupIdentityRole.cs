using Microsoft.EntityFrameworkCore.Migrations;

namespace LocalMealManagement.Migrations
{
    public partial class UserGroupIdentityRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdentityRoleId",
                table: "usersGroups",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_usersGroups_IdentityRoleId",
                table: "usersGroups",
                column: "IdentityRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_usersGroups_AspNetRoles_IdentityRoleId",
                table: "usersGroups",
                column: "IdentityRoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_usersGroups_AspNetRoles_IdentityRoleId",
                table: "usersGroups");

            migrationBuilder.DropIndex(
                name: "IX_usersGroups_IdentityRoleId",
                table: "usersGroups");

            migrationBuilder.DropColumn(
                name: "IdentityRoleId",
                table: "usersGroups");
        }
    }
}
