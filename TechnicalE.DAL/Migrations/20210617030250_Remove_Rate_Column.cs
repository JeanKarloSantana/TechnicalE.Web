using Microsoft.EntityFrameworkCore.Migrations;

namespace TechnicalE.DAL.Migrations
{
    public partial class Remove_Rate_Column : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RateLog",
                table: "PurchaseTransactions");

            migrationBuilder.DropColumn(
                name: "Rate",
                table: "ExchangeRates");

            migrationBuilder.RenameColumn(
                name: "IdTransaction",
                table: "PurchaseTransactions",
                newName: "IdTransactionType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdTransactionType",
                table: "PurchaseTransactions",
                newName: "IdTransaction");

            migrationBuilder.AddColumn<decimal>(
                name: "RateLog",
                table: "PurchaseTransactions",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Rate",
                table: "ExchangeRates",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
