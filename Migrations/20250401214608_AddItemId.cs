using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace w9_assignment_ksteph.Migrations
{
    /// <inheritdoc />
    public partial class AddItemId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Item",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Item");

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "Item",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Item",
                table: "Item",
                column: "ItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Item",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Item");

            migrationBuilder.AddColumn<string>(
                name: "ID",
                table: "Item",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Item",
                table: "Item",
                column: "ID");
        }
    }
}
