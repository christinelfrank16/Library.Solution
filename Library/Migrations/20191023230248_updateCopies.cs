using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class updateCopies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ToBeCheckedOut",
                table: "Copies");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ToBeCheckedOut",
                table: "Copies",
                nullable: false,
                defaultValue: false);
        }
    }
}
