using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocalMealManagement.Migrations
{
    public partial class AccountTableAdding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "accountBalance",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Taka = table.Column<double>(nullable: false),
                    AddedBy = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    IdentityUserId = table.Column<string>(nullable: true),
                    SubGroupsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accountBalance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_accountBalance_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_accountBalance_subGroups_SubGroupsId",
                        column: x => x.SubGroupsId,
                        principalTable: "subGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_accountBalance_IdentityUserId",
                table: "accountBalance",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_accountBalance_SubGroupsId",
                table: "accountBalance",
                column: "SubGroupsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "accountBalance");
        }
    }
}
