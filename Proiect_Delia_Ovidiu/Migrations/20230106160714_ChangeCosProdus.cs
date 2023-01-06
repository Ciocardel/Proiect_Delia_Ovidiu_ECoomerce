using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_Delia_Ovidiu.Migrations
{
    public partial class ChangeCosProdus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cantitate",
                table: "Cosuri");

            migrationBuilder.AddColumn<int>(
                name: "Cantitate",
                table: "CosProduse",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cantitate",
                table: "CosProduse");

            migrationBuilder.AddColumn<int>(
                name: "Cantitate",
                table: "Cosuri",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
