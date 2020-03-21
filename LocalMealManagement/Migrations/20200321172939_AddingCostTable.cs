using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocalMealManagement.Migrations
{
    public partial class AddingCostTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "costTables",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Taka = table.Column<double>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    SubGroupsId = table.Column<int>(nullable: true),
                    IdentityUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_costTables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_costTables_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_costTables_subGroups_SubGroupsId",
                        column: x => x.SubGroupsId,
                        principalTable: "subGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_costTables_IdentityUserId",
                table: "costTables",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_costTables_SubGroupsId",
                table: "costTables",
                column: "SubGroupsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "costTables");
        }
    }
}
