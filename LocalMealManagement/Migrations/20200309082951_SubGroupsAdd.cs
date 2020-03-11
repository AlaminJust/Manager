using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocalMealManagement.Migrations
{
    public partial class SubGroupsAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubGroupsId",
                table: "mealDetails",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "subGroups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubGroupName = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subGroups", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_mealDetails_SubGroupsId",
                table: "mealDetails",
                column: "SubGroupsId");

            migrationBuilder.AddForeignKey(
                name: "FK_mealDetails_subGroups_SubGroupsId",
                table: "mealDetails",
                column: "SubGroupsId",
                principalTable: "subGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mealDetails_subGroups_SubGroupsId",
                table: "mealDetails");

            migrationBuilder.DropTable(
                name: "subGroups");

            migrationBuilder.DropIndex(
                name: "IX_mealDetails_SubGroupsId",
                table: "mealDetails");

            migrationBuilder.DropColumn(
                name: "SubGroupsId",
                table: "mealDetails");
        }
    }
}
