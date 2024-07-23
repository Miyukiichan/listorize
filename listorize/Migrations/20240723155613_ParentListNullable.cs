using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace listorize.Migrations
{
    /// <inheritdoc />
    public partial class ParentListNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ParentListId",
                table: "ListItem",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateIndex(
                name: "IX_ListItem_ParentListId",
                table: "ListItem",
                column: "ParentListId");

            migrationBuilder.AddForeignKey(
                name: "FK_ListItem_List_ParentListId",
                table: "ListItem",
                column: "ParentListId",
                principalTable: "List",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListItem_List_ParentListId",
                table: "ListItem");

            migrationBuilder.DropIndex(
                name: "IX_ListItem_ParentListId",
                table: "ListItem");

            migrationBuilder.AlterColumn<int>(
                name: "ParentListId",
                table: "ListItem",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);
        }
    }
}
