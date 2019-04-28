using Microsoft.EntityFrameworkCore.Migrations;

namespace Marcatto.Migrations
{
    public partial class AlterTable_Income_AddColumn_Description : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Income_BankAccounts_BankAccountId",
                table: "Income");

            migrationBuilder.DropForeignKey(
                name: "FK_Income_PaymentOptions_PaymentOptionId",
                table: "Income");

            migrationBuilder.AlterColumn<int>(
                name: "PaymentOptionId",
                table: "Income",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BankAccountId",
                table: "Income",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Income",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Income_BankAccounts_BankAccountId",
                table: "Income",
                column: "BankAccountId",
                principalTable: "BankAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Income_PaymentOptions_PaymentOptionId",
                table: "Income",
                column: "PaymentOptionId",
                principalTable: "PaymentOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Income_BankAccounts_BankAccountId",
                table: "Income");

            migrationBuilder.DropForeignKey(
                name: "FK_Income_PaymentOptions_PaymentOptionId",
                table: "Income");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Income");

            migrationBuilder.AlterColumn<int>(
                name: "PaymentOptionId",
                table: "Income",
                nullable: true,
                oldClrType: typeof(int));

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

            migrationBuilder.AddForeignKey(
                name: "FK_Income_PaymentOptions_PaymentOptionId",
                table: "Income",
                column: "PaymentOptionId",
                principalTable: "PaymentOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
