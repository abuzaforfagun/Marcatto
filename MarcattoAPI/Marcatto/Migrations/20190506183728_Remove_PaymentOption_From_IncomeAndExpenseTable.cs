using Microsoft.EntityFrameworkCore.Migrations;

namespace Marcatto.Migrations
{
    public partial class Remove_PaymentOption_From_IncomeAndExpenseTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expense_PaymentOptions_PaymentOptionId",
                table: "Expense");

            migrationBuilder.DropForeignKey(
                name: "FK_Income_PaymentOptions_PaymentOptionId",
                table: "Income");

            migrationBuilder.DropIndex(
                name: "IX_Income_PaymentOptionId",
                table: "Income");

            migrationBuilder.DropIndex(
                name: "IX_Expense_PaymentOptionId",
                table: "Expense");

            migrationBuilder.DropColumn(
                name: "PaymentOptionId",
                table: "Income");

            migrationBuilder.DropColumn(
                name: "PaymentOptionId",
                table: "Expense");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PaymentOptionId",
                table: "Income",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "PaymentOptionId",
                table: "Expense",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Income_PaymentOptionId",
                table: "Income",
                column: "PaymentOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_PaymentOptionId",
                table: "Expense",
                column: "PaymentOptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_PaymentOptions_PaymentOptionId",
                table: "Expense",
                column: "PaymentOptionId",
                principalTable: "PaymentOptions",
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
    }
}
