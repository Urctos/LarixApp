using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRelationToOneToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GlassTypes_Windows_WindowId",
                table: "GlassTypes");

            migrationBuilder.DropIndex(
                name: "IX_GlassTypes_WindowId",
                table: "GlassTypes");

            migrationBuilder.DropColumn(
                name: "WindowId",
                table: "GlassTypes");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "GlassTypes",
                newName: "GlassTypeId");

            migrationBuilder.AddColumn<int>(
                name: "GlassTypeId",
                table: "Windows",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Windows",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "GlassTypes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_Windows_GlassTypeId",
                table: "Windows",
                column: "GlassTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Windows_GlassTypes_GlassTypeId",
                table: "Windows",
                column: "GlassTypeId",
                principalTable: "GlassTypes",
                principalColumn: "GlassTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Windows_GlassTypes_GlassTypeId",
                table: "Windows");

            migrationBuilder.DropIndex(
                name: "IX_Windows_GlassTypeId",
                table: "Windows");

            migrationBuilder.DropColumn(
                name: "GlassTypeId",
                table: "Windows");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Windows");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "GlassTypes");

            migrationBuilder.RenameColumn(
                name: "GlassTypeId",
                table: "GlassTypes",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "WindowId",
                table: "GlassTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_GlassTypes_WindowId",
                table: "GlassTypes",
                column: "WindowId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GlassTypes_Windows_WindowId",
                table: "GlassTypes",
                column: "WindowId",
                principalTable: "Windows",
                principalColumn: "Id");
        }
    }
}
