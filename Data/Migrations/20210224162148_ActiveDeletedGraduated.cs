using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class ActiveDeletedGraduated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EventGroup",
                table: "Yotes",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Yotes",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Yotes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "YearGraduated",
                table: "Yotes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventGroup",
                table: "Yotes");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Yotes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Yotes");

            migrationBuilder.DropColumn(
                name: "YearGraduated",
                table: "Yotes");
        }
    }
}
