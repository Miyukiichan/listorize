using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace listorize.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "List",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_List", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lookup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lookup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Note",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Body = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Note", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ListColumn",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ColumnType = table.Column<int>(type: "INTEGER", nullable: false),
                    ListId = table.Column<int>(type: "INTEGER", nullable: false),
                    LookupId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListColumn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListColumn_List_ListId",
                        column: x => x.ListId,
                        principalTable: "List",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListColumn_Lookup_LookupId",
                        column: x => x.LookupId,
                        principalTable: "Lookup",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LookupOption",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    LookupId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookupOption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LookupOption_Lookup_LookupId",
                        column: x => x.LookupId,
                        principalTable: "Lookup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ListItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ParentListId = table.Column<int>(type: "INTEGER", nullable: false),
                    NoteId = table.Column<int>(type: "INTEGER", nullable: true),
                    ListId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListItem_List_ListId",
                        column: x => x.ListId,
                        principalTable: "List",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListItem_Note_NoteId",
                        column: x => x.NoteId,
                        principalTable: "Note",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ListValue",
                columns: table => new
                {
                    ListItemId = table.Column<int>(type: "INTEGER", nullable: false),
                    ListColumnId = table.Column<int>(type: "INTEGER", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListValue", x => new { x.ListItemId, x.ListColumnId });
                    table.ForeignKey(
                        name: "FK_ListValue_ListColumn_ListColumnId",
                        column: x => x.ListColumnId,
                        principalTable: "ListColumn",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListValue_ListItem_ListItemId",
                        column: x => x.ListItemId,
                        principalTable: "ListItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListColumn_ListId",
                table: "ListColumn",
                column: "ListId");

            migrationBuilder.CreateIndex(
                name: "IX_ListColumn_LookupId",
                table: "ListColumn",
                column: "LookupId");

            migrationBuilder.CreateIndex(
                name: "IX_ListItem_ListId",
                table: "ListItem",
                column: "ListId");

            migrationBuilder.CreateIndex(
                name: "IX_ListItem_NoteId",
                table: "ListItem",
                column: "NoteId");

            migrationBuilder.CreateIndex(
                name: "IX_ListValue_ListColumnId",
                table: "ListValue",
                column: "ListColumnId");

            migrationBuilder.CreateIndex(
                name: "IX_LookupOption_LookupId",
                table: "LookupOption",
                column: "LookupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListValue");

            migrationBuilder.DropTable(
                name: "LookupOption");

            migrationBuilder.DropTable(
                name: "ListColumn");

            migrationBuilder.DropTable(
                name: "ListItem");

            migrationBuilder.DropTable(
                name: "Lookup");

            migrationBuilder.DropTable(
                name: "List");

            migrationBuilder.DropTable(
                name: "Note");
        }
    }
}
