using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class updateTransaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CheckoutId",
                table: "Patrons");

            migrationBuilder.DropColumn(
                name: "CheckoutId",
                table: "Copies");

            migrationBuilder.AddColumn<bool>(
                name: "ToBeCheckedOut",
                table: "Copies",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Copies_BookId",
                table: "Copies",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Checkouts_CopyId",
                table: "Checkouts",
                column: "CopyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Checkouts_Copies_CopyId",
                table: "Checkouts",
                column: "CopyId",
                principalTable: "Copies",
                principalColumn: "CopyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Copies_Books_BookId",
                table: "Copies",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checkouts_Copies_CopyId",
                table: "Checkouts");

            migrationBuilder.DropForeignKey(
                name: "FK_Copies_Books_BookId",
                table: "Copies");

            migrationBuilder.DropIndex(
                name: "IX_Copies_BookId",
                table: "Copies");

            migrationBuilder.DropIndex(
                name: "IX_Checkouts_CopyId",
                table: "Checkouts");

            migrationBuilder.DropColumn(
                name: "ToBeCheckedOut",
                table: "Copies");

            migrationBuilder.AddColumn<int>(
                name: "CheckoutId",
                table: "Patrons",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CheckoutId",
                table: "Copies",
                nullable: false,
                defaultValue: 0);
        }
    }
}
