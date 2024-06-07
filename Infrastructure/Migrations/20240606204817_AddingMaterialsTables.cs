using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddingMaterialsTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HingesId",
                table: "Doors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ImpregnationTypeId",
                table: "Doors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WoodId",
                table: "Doors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Hinges",
                columns: table => new
                {
                    HingesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManufacturerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManufacturerDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hinges", x => x.HingesId);
                });

            migrationBuilder.CreateTable(
                name: "ImpregnationTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManufacturerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManufacturerDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImpregnationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Woods",
                columns: table => new
                {
                    WoodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WoodPrice = table.Column<double>(type: "float", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Woods", x => x.WoodId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doors_HingesId",
                table: "Doors",
                column: "HingesId");

            migrationBuilder.CreateIndex(
                name: "IX_Doors_ImpregnationTypeId",
                table: "Doors",
                column: "ImpregnationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Doors_WoodId",
                table: "Doors",
                column: "WoodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doors_Hinges_HingesId",
                table: "Doors",
                column: "HingesId",
                principalTable: "Hinges",
                principalColumn: "HingesId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Doors_ImpregnationTypes_ImpregnationTypeId",
                table: "Doors",
                column: "ImpregnationTypeId",
                principalTable: "ImpregnationTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Doors_Woods_WoodId",
                table: "Doors",
                column: "WoodId",
                principalTable: "Woods",
                principalColumn: "WoodId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doors_Hinges_HingesId",
                table: "Doors");

            migrationBuilder.DropForeignKey(
                name: "FK_Doors_ImpregnationTypes_ImpregnationTypeId",
                table: "Doors");

            migrationBuilder.DropForeignKey(
                name: "FK_Doors_Woods_WoodId",
                table: "Doors");

            migrationBuilder.DropTable(
                name: "Hinges");

            migrationBuilder.DropTable(
                name: "ImpregnationTypes");

            migrationBuilder.DropTable(
                name: "Woods");

            migrationBuilder.DropIndex(
                name: "IX_Doors_HingesId",
                table: "Doors");

            migrationBuilder.DropIndex(
                name: "IX_Doors_ImpregnationTypeId",
                table: "Doors");

            migrationBuilder.DropIndex(
                name: "IX_Doors_WoodId",
                table: "Doors");

            migrationBuilder.DropColumn(
                name: "HingesId",
                table: "Doors");

            migrationBuilder.DropColumn(
                name: "ImpregnationTypeId",
                table: "Doors");

            migrationBuilder.DropColumn(
                name: "WoodId",
                table: "Doors");
        }
    }
}
