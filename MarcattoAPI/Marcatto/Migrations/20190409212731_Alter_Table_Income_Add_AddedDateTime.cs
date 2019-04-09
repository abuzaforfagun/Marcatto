using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Marcatto.Migrations
{
    public partial class Alter_Table_Income_Add_AddedDateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AddedDateTime",
                table: "Income",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddedDateTime",
                table: "Income");
        }
    }
}
