using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IteachAPI.Migrations
{
    /// <inheritdoc />
    public partial class UserTesttabela : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserTestTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTestTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTestTable_TestTable_TestId",
                        column: x => x.TestId,
                        principalTable: "TestTable",
                        principalColumn: "TestId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTestTable_UserTable_UserId",
                        column: x => x.UserId,
                        principalTable: "UserTable",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserTestTable_TestId",
                table: "UserTestTable",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTestTable_UserId",
                table: "UserTestTable",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserTestTable");
        }
    }
}
