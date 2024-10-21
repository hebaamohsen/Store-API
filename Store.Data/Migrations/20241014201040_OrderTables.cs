using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Data.Migrations
{
    /// <inheritdoc />
    public partial class OrderTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_ProductItem_productItemProductId",
                table: "OrderItem");

            migrationBuilder.DropTable(
                name: "ProductItem");

            migrationBuilder.DropIndex(
                name: "IX_OrderItem_productItemProductId",
                table: "OrderItem");

            migrationBuilder.RenameColumn(
                name: "productItemProductId",
                table: "OrderItem",
                newName: "productItem_ProductId");

            migrationBuilder.AddColumn<string>(
                name: "productItem_PictureUrl",
                table: "OrderItem",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "productItem_ProductName",
                table: "OrderItem",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "productItem_PictureUrl",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "productItem_ProductName",
                table: "OrderItem");

            migrationBuilder.RenameColumn(
                name: "productItem_ProductId",
                table: "OrderItem",
                newName: "productItemProductId");

            migrationBuilder.CreateTable(
                name: "ProductItem",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductItem", x => x.ProductId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_productItemProductId",
                table: "OrderItem",
                column: "productItemProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_ProductItem_productItemProductId",
                table: "OrderItem",
                column: "productItemProductId",
                principalTable: "ProductItem",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
