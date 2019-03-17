using Microsoft.EntityFrameworkCore.Migrations;

namespace Modeling.Migrations
{
    public partial class FluentApi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogImages_Blogs_BlogId",
                table: "BlogImages");

            migrationBuilder.RenameColumn(
                name: "BlogId",
                table: "BlogImages",
                newName: "BlogForeignKey");

            migrationBuilder.RenameIndex(
                name: "IX_BlogImages_BlogId",
                table: "BlogImages",
                newName: "IX_BlogImages_BlogForeignKey");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogImages_Blogs_BlogForeignKey",
                table: "BlogImages",
                column: "BlogForeignKey",
                principalTable: "Blogs",
                principalColumn: "BlogId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogImages_Blogs_BlogForeignKey",
                table: "BlogImages");

            migrationBuilder.RenameColumn(
                name: "BlogForeignKey",
                table: "BlogImages",
                newName: "BlogId");

            migrationBuilder.RenameIndex(
                name: "IX_BlogImages_BlogForeignKey",
                table: "BlogImages",
                newName: "IX_BlogImages_BlogId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogImages_Blogs_BlogId",
                table: "BlogImages",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "BlogId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
