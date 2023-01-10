using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_Delia_Ovidiu.Migrations
{
    public partial class addImageOnProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Produse",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Produse");
        }
    }
}
