using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvaluationBackend.Data.Migrations
{
    /// <inheritdoc />
    public partial class mohammeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "City",
                table: "VehicleCities",
                newName: "VehicleGovernarte");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VehicleGovernarte",
                table: "VehicleCities",
                newName: "City");
        }
    }
}
