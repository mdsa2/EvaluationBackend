using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvaluationBackend.Migrations
{
    /// <inheritdoc />
    public partial class IntailCreatedadasadssda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fines_Gov_GovId",
                table: "fines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gov",
                table: "Gov");

            migrationBuilder.RenameTable(
                name: "Gov",
                newName: "govs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_govs",
                table: "govs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_fines_govs_GovId",
                table: "fines",
                column: "GovId",
                principalTable: "govs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fines_govs_GovId",
                table: "fines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_govs",
                table: "govs");

            migrationBuilder.RenameTable(
                name: "govs",
                newName: "Gov");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gov",
                table: "Gov",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_fines_Gov_GovId",
                table: "fines",
                column: "GovId",
                principalTable: "Gov",
                principalColumn: "Id");
        }
    }
}
