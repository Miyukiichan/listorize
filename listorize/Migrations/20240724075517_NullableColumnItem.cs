using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace listorize.Migrations
{
    /// <inheritdoc />
    public partial class NullableColumnItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemColumns_Items_ItemId",
                table: "ItemColumns");

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "ItemColumns",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemColumns_Items_ItemId",
                table: "ItemColumns",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemColumns_Items_ItemId",
                table: "ItemColumns");

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "ItemColumns",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemColumns_Items_ItemId",
                table: "ItemColumns",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
