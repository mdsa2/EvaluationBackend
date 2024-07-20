using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvaluationBackend.Data.Migrations
{
    /// <inheritdoc />
    public partial class mohammedsda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "fines",
                type: "numeric",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "fines");
        }
    }
}
