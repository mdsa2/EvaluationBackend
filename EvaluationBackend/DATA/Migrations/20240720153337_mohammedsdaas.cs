using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvaluationBackend.Data.Migrations
{
    /// <inheritdoc />
    public partial class mohammedsdaas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehical_VehicleCities_VehicleCityId",
                table: "Vehical");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VehicleCities",
                table: "VehicleCities");

            migrationBuilder.RenameTable(
                name: "VehicleCities",
                newName: "VehiclesGovernaretes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VehiclesGovernaretes",
                table: "VehiclesGovernaretes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehical_VehiclesGovernaretes_VehicleCityId",
                table: "Vehical",
                column: "VehicleCityId",
                principalTable: "VehiclesGovernaretes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehical_VehiclesGovernaretes_VehicleCityId",
                table: "Vehical");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VehiclesGovernaretes",
                table: "VehiclesGovernaretes");

            migrationBuilder.RenameTable(
                name: "VehiclesGovernaretes",
                newName: "VehicleCities");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VehicleCities",
                table: "VehicleCities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehical_VehicleCities_VehicleCityId",
                table: "Vehical",
                column: "VehicleCityId",
                principalTable: "VehicleCities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
