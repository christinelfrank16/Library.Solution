using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class updatePatron : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CopyId",
                table: "Patrons");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Patrons",
                newName: "UserId");

            migrationBuilder.AddColumn<int>(
                name: "PatronId",
                table: "Transactions",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Patrons",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_PatronId",
                table: "Transactions",
                column: "PatronId");

            migrationBuilder.CreateIndex(
                name: "IX_Patrons_UserId",
                table: "Patrons",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patrons_AspNetUsers_UserId",
                table: "Patrons",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Patrons_PatronId",
                table: "Transactions",
                column: "PatronId",
                principalTable: "Patrons",
                principalColumn: "PatronId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patrons_AspNetUsers_UserId",
                table: "Patrons");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Patrons_PatronId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_PatronId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Patrons_UserId",
                table: "Patrons");

            migrationBuilder.DropColumn(
                name: "PatronId",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Patrons",
                newName: "Email");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Patrons",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CopyId",
                table: "Patrons",
                nullable: false,
                defaultValue: 0);
        }
    }
}
