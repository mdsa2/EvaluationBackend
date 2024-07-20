using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvaluationBackend.Data.Migrations
{
    /// <inheritdoc />
    public partial class Secondseesfas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "fines",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "fines");
        }
    }
}
