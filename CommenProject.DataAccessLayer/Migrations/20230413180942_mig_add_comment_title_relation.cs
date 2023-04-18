using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommenProject.DataAccessLayer.Migrations
{
    public partial class mig_add_comment_title_relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TitleID",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_TitleID",
                table: "Comments",
                column: "TitleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Titles_TitleID",
                table: "Comments",
                column: "TitleID",
                principalTable: "Titles",
                principalColumn: "TitleID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Titles_TitleID",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_TitleID",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "TitleID",
                table: "Comments");
        }
    }
}
