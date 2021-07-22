using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookRental.Migrations
{
    public partial class AddRentDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Rented",
                table: "Rents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Returned",
                table: "Rents",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rented",
                table: "Rents");

            migrationBuilder.DropColumn(
                name: "Returned",
                table: "Rents");
        }
    }
}
