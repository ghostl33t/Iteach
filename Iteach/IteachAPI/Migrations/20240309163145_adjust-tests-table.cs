using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IteachAPI.Migrations
{
    /// <inheritdoc />
    public partial class adjustteststable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tests_Users_UserId",
                table: "Tests");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Tests",
                newName: "TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_Tests_UserId",
                table: "Tests",
                newName: "IX_Tests_TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_Users_TeacherId",
                table: "Tests",
                column: "TeacherId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tests_Users_TeacherId",
                table: "Tests");

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "Tests",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Tests_TeacherId",
                table: "Tests",
                newName: "IX_Tests_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_Users_UserId",
                table: "Tests",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
