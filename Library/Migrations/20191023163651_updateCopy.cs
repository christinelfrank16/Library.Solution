using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class updateCopy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checkouts_Copies_CopyId",
                table: "Checkouts");

            migrationBuilder.DropIndex(
                name: "IX_Checkouts_CopyId",
                table: "Checkouts");

            migrationBuilder.AddColumn<int>(
                name: "CheckoutId",
                table: "Copies",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checkouts_Copies_CopyId1",
                table: "Checkouts");

            migrationBuilder.DropIndex(
                name: "IX_Checkouts_CopyId1",
                table: "Checkouts");

            migrationBuilder.DropColumn(
                name: "CheckoutId",
                table: "Copies");

            migrationBuilder.DropColumn(
                name: "CopyId1",
                table: "Checkouts");

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
        }
    }
}
