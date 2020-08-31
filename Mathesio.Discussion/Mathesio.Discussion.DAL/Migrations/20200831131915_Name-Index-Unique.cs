using Microsoft.EntityFrameworkCore.Migrations;

namespace Mathesio.Discussion.DAL.Migrations
{
    public partial class NameIndexUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Authors_Name",
                table: "Authors",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Authors_Name",
                table: "Authors");
        }
    }
}
