using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IteachAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TeachPlanTable",
                columns: table => new
                {
                    TeachPlanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeachPlanTable", x => x.TeachPlanId);
                });

            migrationBuilder.CreateTable(
                name: "TestTable",
                columns: table => new
                {
                    TestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestTable", x => x.TestId);
                });

            migrationBuilder.CreateTable(
                name: "UserTable",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Roles = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTable", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "ChildsTable",
                columns: table => new
                {
                    ChildId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildsTable", x => x.ChildId);
                    table.ForeignKey(
                        name: "FK_ChildsTable_UserTable_ParentUserId",
                        column: x => x.ParentUserId,
                        principalTable: "UserTable",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeachPlanUserTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeachPlanId = table.Column<int>(type: "int", nullable: false),
                    TeacherUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeachPlanUserTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeachPlanUserTable_TeachPlanTable_TeachPlanId",
                        column: x => x.TeachPlanId,
                        principalTable: "TeachPlanTable",
                        principalColumn: "TeachPlanId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeachPlanUserTable_UserTable_TeacherUserId",
                        column: x => x.TeacherUserId,
                        principalTable: "UserTable",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChildTestTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChildId = table.Column<int>(type: "int", nullable: false),
                    TestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildTestTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChildTestTable_ChildsTable_ChildId",
                        column: x => x.ChildId,
                        principalTable: "ChildsTable",
                        principalColumn: "ChildId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChildTestTable_TestTable_TestId",
                        column: x => x.TestId,
                        principalTable: "TestTable",
                        principalColumn: "TestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestResponseTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestId = table.Column<int>(type: "int", nullable: false),
                    ChildId = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestResponseTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestResponseTable_ChildsTable_ChildId",
                        column: x => x.ChildId,
                        principalTable: "ChildsTable",
                        principalColumn: "ChildId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestResponseTable_TestTable_TestId",
                        column: x => x.TestId,
                        principalTable: "TestTable",
                        principalColumn: "TestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChildsTable_ParentUserId",
                table: "ChildsTable",
                column: "ParentUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ChildTestTable_ChildId",
                table: "ChildTestTable",
                column: "ChildId");

            migrationBuilder.CreateIndex(
                name: "IX_ChildTestTable_TestId",
                table: "ChildTestTable",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_TeachPlanUserTable_TeacherUserId",
                table: "TeachPlanUserTable",
                column: "TeacherUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TeachPlanUserTable_TeachPlanId",
                table: "TeachPlanUserTable",
                column: "TeachPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_TestResponseTable_ChildId",
                table: "TestResponseTable",
                column: "ChildId");

            migrationBuilder.CreateIndex(
                name: "IX_TestResponseTable_TestId",
                table: "TestResponseTable",
                column: "TestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChildTestTable");

            migrationBuilder.DropTable(
                name: "TeachPlanUserTable");

            migrationBuilder.DropTable(
                name: "TestResponseTable");

            migrationBuilder.DropTable(
                name: "TeachPlanTable");

            migrationBuilder.DropTable(
                name: "ChildsTable");

            migrationBuilder.DropTable(
                name: "TestTable");

            migrationBuilder.DropTable(
                name: "UserTable");
        }
    }
}
