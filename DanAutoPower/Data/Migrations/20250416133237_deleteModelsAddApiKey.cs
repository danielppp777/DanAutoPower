using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DanAutoPower.Data.Migrations
{
    /// <inheritdoc />
    public partial class deleteModelsAddApiKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Cars_CarId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Models_ModelID",
                table: "Cars");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropIndex(
                name: "IX_Cars_CarId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_ModelID",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "YearOfManifacture",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "ModelID",
                table: "Cars",
                newName: "YearOfManufacture");

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Fuel",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Mileage",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Fuel",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Mileage",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "YearOfManufacture",
                table: "Cars",
                newName: "ModelID");

            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "Cars",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "YearOfManifacture",
                table: "Cars",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Models_Brands_BrandID",
                        column: x => x.BrandID,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarId",
                table: "Cars",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ModelID",
                table: "Cars",
                column: "ModelID");

            migrationBuilder.CreateIndex(
                name: "IX_Models_BrandID",
                table: "Models",
                column: "BrandID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Cars_CarId",
                table: "Cars",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Models_ModelID",
                table: "Cars",
                column: "ModelID",
                principalTable: "Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
