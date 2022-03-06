using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoApi.Migrations
{
    public partial class ChangeInAccountModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TodoLists_AccountId",
                table: "TodoLists");

            migrationBuilder.CreateIndex(
                name: "IX_TodoLists_AccountId",
                table: "TodoLists",
                column: "AccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TodoLists_AccountId",
                table: "TodoLists");

            migrationBuilder.CreateIndex(
                name: "IX_TodoLists_AccountId",
                table: "TodoLists",
                column: "AccountId",
                unique: true);
        }
    }
}
