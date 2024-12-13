using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductApp.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueConstraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "p_Name_cid_unique",
                table: "Products",
                columns: new[] { "ProductName", "CategoryId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "C_Name_unique",
                table: "Categories",
                column: "CategoryName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "p_Name_cid_unique",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "C_Name_unique",
                table: "Categories");
        }
    }
}
