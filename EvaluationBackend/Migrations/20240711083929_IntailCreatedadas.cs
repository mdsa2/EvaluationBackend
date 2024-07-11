using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EvaluationBackend.Migrations
{
    /// <inheritdoc />
    public partial class IntailCreatedadas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "citizens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Phonenumber = table.Column<int>(type: "integer", nullable: true),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_citizens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "fineTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<decimal>(type: "numeric", nullable: true),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fineTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gov",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gov", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "placeFines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_placeFines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfVehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfVehicles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehical",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NumberOfVechile = table.Column<int>(type: "integer", nullable: true),
                    GovOfVehicle = table.Column<string>(type: "text", nullable: true),
                    carPartNumber = table.Column<string>(type: "text", nullable: true),
                    CitizenId = table.Column<int>(type: "integer", nullable: true),
                    TypeOfVechileId = table.Column<int>(type: "integer", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehical", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehical_TypeOfVehicles_TypeOfVechileId",
                        column: x => x.TypeOfVechileId,
                        principalTable: "TypeOfVehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehical_citizens_CitizenId",
                        column: x => x.CitizenId,
                        principalTable: "citizens",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "fines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GovId = table.Column<int>(type: "integer", nullable: true),
                    DesNumber = table.Column<int>(type: "integer", nullable: true),
                    Number = table.Column<int>(type: "integer", nullable: true),
                    FineTypeId = table.Column<int>(type: "integer", nullable: true),
                    PlaceFineId = table.Column<int>(type: "integer", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: true),
                    VechileId = table.Column<int>(type: "integer", nullable: true),
                    VehicleId = table.Column<int>(type: "integer", nullable: true),
                    AppUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_fines_Gov_GovId",
                        column: x => x.GovId,
                        principalTable: "Gov",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_fines_Users_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_fines_Vehical_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehical",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_fines_fineTypes_FineTypeId",
                        column: x => x.FineTypeId,
                        principalTable: "fineTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_fines_placeFines_PlaceFineId",
                        column: x => x.PlaceFineId,
                        principalTable: "placeFines",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_fines_AppUserId",
                table: "fines",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_fines_FineTypeId",
                table: "fines",
                column: "FineTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_fines_GovId",
                table: "fines",
                column: "GovId");

            migrationBuilder.CreateIndex(
                name: "IX_fines_PlaceFineId",
                table: "fines",
                column: "PlaceFineId");

            migrationBuilder.CreateIndex(
                name: "IX_fines_VehicleId",
                table: "fines",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehical_CitizenId",
                table: "Vehical",
                column: "CitizenId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehical_TypeOfVechileId",
                table: "Vehical",
                column: "TypeOfVechileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "fines");

            migrationBuilder.DropTable(
                name: "Gov");

            migrationBuilder.DropTable(
                name: "Vehical");

            migrationBuilder.DropTable(
                name: "fineTypes");

            migrationBuilder.DropTable(
                name: "placeFines");

            migrationBuilder.DropTable(
                name: "TypeOfVehicles");

            migrationBuilder.DropTable(
                name: "citizens");
        }
    }
}
