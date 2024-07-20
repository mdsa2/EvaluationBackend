using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvaluationBackend.Data.Migrations
{
    /// <inheritdoc />
    public partial class Secondseesfass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "character",
                table: "Vehical",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserImage",
                table: "Users",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "character",
                table: "Vehical");

            migrationBuilder.DropColumn(
                name: "UserImage",
                table: "Users");
        }
    }
}
