using Microsoft.EntityFrameworkCore.Migrations;

namespace Marcatto.Migrations
{
    public partial class Insert_DummyData_PaymentOptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO PaymentOptions (Name) Values ('Efectivo')");
            migrationBuilder.Sql("INSERT INTO PaymentOptions (Name) Values ('Tarjeta')");
            migrationBuilder.Sql("INSERT INTO PaymentOptions (Name) Values ('Deposito')");
            migrationBuilder.Sql("INSERT INTO PaymentOptions (Name) Values ('Transferencia')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM PaymentOptions WHERE Name IN ('Efectivo', 'Tarjeta', 'Deposito', 'Transferencia')");
        }
    }
}
