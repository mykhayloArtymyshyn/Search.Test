using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Search.Test.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddQueryIndex2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Queries_UserId_Text",
                table: "Queries");

            migrationBuilder.CreateIndex(
                name: "IX_Queries_UserId_Text_Category",
                table: "Queries",
                columns: new[] { "UserId", "Text", "Category" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Queries_UserId_Text_Category",
                table: "Queries");

            migrationBuilder.CreateIndex(
                name: "IX_Queries_UserId_Text",
                table: "Queries",
                columns: new[] { "UserId", "Text" },
                unique: true);
        }
    }
}
