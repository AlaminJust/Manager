using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocalMealManagement.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Day",
                table: "mealDetails");

            migrationBuilder.DropColumn(
                name: "MonthWithYear",
                table: "mealDetails");

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderDate",
                table: "mealDetails",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderDate",
                table: "mealDetails");

            migrationBuilder.AddColumn<string>(
                name: "Day",
                table: "mealDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MonthWithYear",
                table: "mealDetails",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
