using Microsoft.EntityFrameworkCore.Migrations;

namespace TechnicalE.DAL.Migrations
{
    public partial class Add_Column_Amount_ToTbl_PurchaseTransaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "PurchaseTransactions",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "PurchaseTransactions");
        }
    }
}
