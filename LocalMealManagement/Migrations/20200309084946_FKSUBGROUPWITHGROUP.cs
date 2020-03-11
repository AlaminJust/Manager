using Microsoft.EntityFrameworkCore.Migrations;

namespace LocalMealManagement.Migrations
{
    public partial class FKSUBGROUPWITHGROUP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupsGroupId",
                table: "subGroups",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_subGroups_GroupsGroupId",
                table: "subGroups",
                column: "GroupsGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_subGroups_groups_GroupsGroupId",
                table: "subGroups",
                column: "GroupsGroupId",
                principalTable: "groups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_subGroups_groups_GroupsGroupId",
                table: "subGroups");

            migrationBuilder.DropIndex(
                name: "IX_subGroups_GroupsGroupId",
                table: "subGroups");

            migrationBuilder.DropColumn(
                name: "GroupsGroupId",
                table: "subGroups");
        }
    }
}
