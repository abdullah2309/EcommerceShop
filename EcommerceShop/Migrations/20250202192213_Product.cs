using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceShop.Migrations
{
    /// <inheritdoc />
    public partial class Product : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "addCategories",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    category_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_addCategories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "addProducts",
                columns: table => new
                {
                    Product_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Product_Price = table.Column<int>(type: "int", nullable: false),
                    Product_Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Product_Images = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    category_list = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_addProducts", x => x.Product_id);
                    table.ForeignKey(
                        name: "FK_addProducts_addCategories_category_list",
                        column: x => x.category_list,
                        principalTable: "addCategories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_addProducts_category_list",
                table: "addProducts",
                column: "category_list");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "addProducts");

            migrationBuilder.DropTable(
                name: "addCategories");
        }
    }
}
