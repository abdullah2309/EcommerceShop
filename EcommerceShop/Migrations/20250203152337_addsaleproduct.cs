using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceShop.Migrations
{
    /// <inheritdoc />
    public partial class addsaleproduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "addProductsales",
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
                    table.PrimaryKey("PK_addProductsales", x => x.Product_id);
                    table.ForeignKey(
                        name: "FK_addProductsales_addCategories_category_list",
                        column: x => x.category_list,
                        principalTable: "addCategories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_addProductsales_category_list",
                table: "addProductsales",
                column: "category_list");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "addProductsales");
        }
    }
}
