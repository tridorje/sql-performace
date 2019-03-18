using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Dat.Migrations
{
    public partial class manytomany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TestTableId",
                table: "TestTable1",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TestTable2",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    value = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestTable2", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Test1Test2",
                columns: table => new
                {
                    TestTable1Id = table.Column<int>(nullable: false),
                    TestTable2Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test1Test2", x => new { x.TestTable1Id, x.TestTable2Id });
                    table.ForeignKey(
                        name: "FK_Test1Test2_TestTable1_TestTable1Id",
                        column: x => x.TestTable1Id,
                        principalTable: "TestTable1",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Test1Test2_TestTable2_TestTable2Id",
                        column: x => x.TestTable2Id,
                        principalTable: "TestTable2",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestTable1_TestTableId",
                table: "TestTable1",
                column: "TestTableId");

            migrationBuilder.CreateIndex(
                name: "IX_Test1Test2_TestTable2Id",
                table: "Test1Test2",
                column: "TestTable2Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TestTable1_TestTable_TestTableId",
                table: "TestTable1",
                column: "TestTableId",
                principalTable: "TestTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestTable1_TestTable_TestTableId",
                table: "TestTable1");

            migrationBuilder.DropTable(
                name: "Test1Test2");

            migrationBuilder.DropTable(
                name: "TestTable2");

            migrationBuilder.DropIndex(
                name: "IX_TestTable1_TestTableId",
                table: "TestTable1");

            migrationBuilder.DropColumn(
                name: "TestTableId",
                table: "TestTable1");
        }
    }
}
