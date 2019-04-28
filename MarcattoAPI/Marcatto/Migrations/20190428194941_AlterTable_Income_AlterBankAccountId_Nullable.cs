using Microsoft.EntityFrameworkCore.Migrations;

namespace Marcatto.Migrations
{
    public partial class AlterTable_Income_AlterBankAccountId_Nullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Income_BankAccounts_BankAccountId",
                table: "Income");

            migrationBuilder.AlterColumn<int>(
                name: "BankAccountId",
                table: "Income",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Income_BankAccounts_BankAccountId",
                table: "Income",
                column: "BankAccountId",
                principalTable: "BankAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Income_BankAccounts_BankAccountId",
                table: "Income");

            migrationBuilder.AlterColumn<int>(
                name: "BankAccountId",
                table: "Income",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Income_BankAccounts_BankAccountId",
                table: "Income",
                column: "BankAccountId",
                principalTable: "BankAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
