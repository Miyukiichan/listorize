using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace listorize.Migrations
{
    /// <inheritdoc />
    public partial class ListItemNullableList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListItem_List_ListId",
                table: "ListItem");

            migrationBuilder.AlterColumn<int>(
                name: "ListId",
                table: "ListItem",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_ListItem_List_ListId",
                table: "ListItem",
                column: "ListId",
                principalTable: "List",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListItem_List_ListId",
                table: "ListItem");

            migrationBuilder.AlterColumn<int>(
                name: "ListId",
                table: "ListItem",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ListItem_List_ListId",
                table: "ListItem",
                column: "ListId",
                principalTable: "List",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
