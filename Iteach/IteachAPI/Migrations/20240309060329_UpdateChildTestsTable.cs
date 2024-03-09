using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IteachAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateChildTestsTable : Migration
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

            migrationBuilder.AddColumn<string>(
                name: "TeacherFeedback",
                table: "ChildTestTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChildTestTable_ChildsTable_ChildId",
                table: "ChildTestTable");

            migrationBuilder.DropForeignKey(
                name: "FK_ChildTestTable_TestTable_TestId",
                table: "ChildTestTable");

            migrationBuilder.DropColumn(
                name: "TeacherFeedback",
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
    }
}
