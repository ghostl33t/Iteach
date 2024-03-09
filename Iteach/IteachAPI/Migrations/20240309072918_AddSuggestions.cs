using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IteachAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddSuggestions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChildTestTable_ChildsTable_ChildId",
                table: "ChildTestTable");

            migrationBuilder.DropForeignKey(
                name: "FK_ChildTestTable_TestTable_TestId",
                table: "ChildTestTable");

            migrationBuilder.AlterColumn<long>(
                name: "TestId",
                table: "ChildTestTable",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ChildId",
                table: "ChildTestTable",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ChildTestTable",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateTable(
                name: "Suggestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChildId = table.Column<long>(type: "bigint", nullable: false),
                    SuggestionText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SuggestionBasedOnTests = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suggestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suggestions_ChildsTable_ChildId",
                        column: x => x.ChildId,
                        principalTable: "ChildsTable",
                        principalColumn: "ChildId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Suggestions_ChildId",
                table: "Suggestions",
                column: "ChildId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChildTestTable_ChildsTable_ChildId",
                table: "ChildTestTable",
                column: "ChildId",
                principalTable: "ChildsTable",
                principalColumn: "ChildId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChildTestTable_TestTable_TestId",
                table: "ChildTestTable",
                column: "TestId",
                principalTable: "TestTable",
                principalColumn: "TestId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChildTestTable_ChildsTable_ChildId",
                table: "ChildTestTable");

            migrationBuilder.DropForeignKey(
                name: "FK_ChildTestTable_TestTable_TestId",
                table: "ChildTestTable");

            migrationBuilder.DropTable(
                name: "Suggestions");

            migrationBuilder.AlterColumn<long>(
                name: "TestId",
                table: "ChildTestTable",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "ChildId",
                table: "ChildTestTable",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "ChildTestTable",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddForeignKey(
                name: "FK_ChildTestTable_ChildsTable_ChildId",
                table: "ChildTestTable",
                column: "ChildId",
                principalTable: "ChildsTable",
                principalColumn: "ChildId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChildTestTable_TestTable_TestId",
                table: "ChildTestTable",
                column: "TestId",
                principalTable: "TestTable",
                principalColumn: "TestId");
        }
    }
}
