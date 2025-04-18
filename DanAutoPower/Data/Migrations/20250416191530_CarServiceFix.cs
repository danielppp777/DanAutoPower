using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DanAutoPower.Data.Migrations
{
    /// <inheritdoc />
    public partial class CarServiceFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "YearOfManufacture",
                table: "Cars",
                newName: "Year");

            migrationBuilder.RenameColumn(
                name: "Brand",
                table: "Cars",
                newName: "Make");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Year",
                table: "Cars",
                newName: "YearOfManufacture");

            migrationBuilder.RenameColumn(
                name: "Make",
                table: "Cars",
                newName: "Brand");
        }
    }
}
