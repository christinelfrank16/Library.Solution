using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class addTransactions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checkouts_Copies_CopyId1",
                table: "Checkouts");

            migrationBuilder.DropIndex(
                name: "IX_Checkouts_CopyId1",
                table: "Checkouts");

            migrationBuilder.DropColumn(
                name: "CopyId1",
                table: "Checkouts");

            migrationBuilder.AddColumn<int>(
                name: "TransactionId",
                table: "Checkouts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CheckoutId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Transactions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Checkouts_TransactionId",
                table: "Checkouts",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_UserId",
                table: "Transactions",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Checkouts_Transactions_TransactionId",
                table: "Checkouts",
                column: "TransactionId",
                principalTable: "Transactions",
                principalColumn: "TransactionId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checkouts_Transactions_TransactionId",
                table: "Checkouts");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Checkouts_TransactionId",
                table: "Checkouts");

            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "Checkouts");

            migrationBuilder.AddColumn<int>(
                name: "CopyId1",
                table: "Checkouts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Checkouts_CopyId1",
                table: "Checkouts",
                column: "CopyId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Checkouts_Copies_CopyId1",
                table: "Checkouts",
                column: "CopyId1",
                principalTable: "Copies",
                principalColumn: "CopyId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
