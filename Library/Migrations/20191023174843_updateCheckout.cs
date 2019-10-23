using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class updateCheckout : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CheckoutId",
                table: "Transactions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CheckoutId",
                table: "Transactions",
                nullable: false,
                defaultValue: 0);
        }
    }
}
