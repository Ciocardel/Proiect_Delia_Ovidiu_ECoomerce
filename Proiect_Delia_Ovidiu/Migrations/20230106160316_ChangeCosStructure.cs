using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_Delia_Ovidiu.Migrations
{
    public partial class ChangeCosStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Cosuri_CosId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CosId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CosId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Cosuri",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Cosuri_UserId",
                table: "Cosuri",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cosuri_AspNetUsers_UserId",
                table: "Cosuri",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cosuri_AspNetUsers_UserId",
                table: "Cosuri");

            migrationBuilder.DropIndex(
                name: "IX_Cosuri_UserId",
                table: "Cosuri");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Cosuri",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "CosId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CosId",
                table: "AspNetUsers",
                column: "CosId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Cosuri_CosId",
                table: "AspNetUsers",
                column: "CosId",
                principalTable: "Cosuri",
                principalColumn: "Id");
        }
    }
}
