using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EvaluationBackend.Data.Migrations
{
    /// <inheritdoc />
    public partial class mohammedsdaasss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehical_VehiclesGovernaretes_VehicleCityId",
                table: "Vehical");

            migrationBuilder.DropIndex(
                name: "IX_Vehical_VehicleCityId",
                table: "Vehical");

            migrationBuilder.DropColumn(
                name: "character",
                table: "Vehical");

            migrationBuilder.AddColumn<int>(
                name: "characterId",
                table: "Vehical",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "vehiclesGovernareteId",
                table: "Vehical",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "garageName",
                table: "fines",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CharacterName = table.Column<string>(type: "text", nullable: true),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehical_characterId",
                table: "Vehical",
                column: "characterId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehical_vehiclesGovernareteId",
                table: "Vehical",
                column: "vehiclesGovernareteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehical_Character_characterId",
                table: "Vehical",
                column: "characterId",
                principalTable: "Character",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehical_VehiclesGovernaretes_vehiclesGovernareteId",
                table: "Vehical",
                column: "vehiclesGovernareteId",
                principalTable: "VehiclesGovernaretes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehical_Character_characterId",
                table: "Vehical");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehical_VehiclesGovernaretes_vehiclesGovernareteId",
                table: "Vehical");

            migrationBuilder.DropTable(
                name: "Character");

            migrationBuilder.DropIndex(
                name: "IX_Vehical_characterId",
                table: "Vehical");

            migrationBuilder.DropIndex(
                name: "IX_Vehical_vehiclesGovernareteId",
                table: "Vehical");

            migrationBuilder.DropColumn(
                name: "characterId",
                table: "Vehical");

            migrationBuilder.DropColumn(
                name: "vehiclesGovernareteId",
                table: "Vehical");

            migrationBuilder.DropColumn(
                name: "garageName",
                table: "fines");

            migrationBuilder.AddColumn<string>(
                name: "character",
                table: "Vehical",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehical_VehicleCityId",
                table: "Vehical",
                column: "VehicleCityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehical_VehiclesGovernaretes_VehicleCityId",
                table: "Vehical",
                column: "VehicleCityId",
                principalTable: "VehiclesGovernaretes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
