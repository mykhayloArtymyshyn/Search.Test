using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Search.Test.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddQueryIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Queries_UserId",
                table: "Queries");

            migrationBuilder.DropColumn(
                name: "ImdbId",
                table: "Results");

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Queries",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Queries_UserId_Text",
                table: "Queries",
                columns: new[] { "UserId", "Text" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Queries_UserId_Text",
                table: "Queries");

            migrationBuilder.AddColumn<string>(
                name: "ImdbId",
                table: "Results",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Queries",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_Queries_UserId",
                table: "Queries",
                column: "UserId");
        }
    }
}
