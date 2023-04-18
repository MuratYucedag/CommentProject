using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommenProject.DataAccessLayer.Migrations
{
    public partial class mig_add_category_title_relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Titles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Titles_CategoryID",
                table: "Titles",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Titles_Categories_CategoryID",
                table: "Titles",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Titles_Categories_CategoryID",
                table: "Titles");

            migrationBuilder.DropIndex(
                name: "IX_Titles_CategoryID",
                table: "Titles");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Titles");
        }
    }
}
