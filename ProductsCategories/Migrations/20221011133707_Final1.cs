using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductsCategories.Migrations
{
    public partial class Final1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Association_Category_CategoryId",
                table: "Association");

            migrationBuilder.DropForeignKey(
                name: "FK_Association_Products_ProductId",
                table: "Association");

            migrationBuilder.DropForeignKey(
                name: "FK_Category_Products_ProductId",
                table: "Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Association",
                table: "Association");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.RenameTable(
                name: "Association",
                newName: "Associations");

            migrationBuilder.RenameIndex(
                name: "IX_Category_ProductId",
                table: "Categories",
                newName: "IX_Categories_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Association_ProductId",
                table: "Associations",
                newName: "IX_Associations_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Association_CategoryId",
                table: "Associations",
                newName: "IX_Associations_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Associations",
                table: "Associations",
                column: "AssociationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Associations_Categories_CategoryId",
                table: "Associations",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Associations_Products_ProductId",
                table: "Associations",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Products_ProductId",
                table: "Categories",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Associations_Categories_CategoryId",
                table: "Associations");

            migrationBuilder.DropForeignKey(
                name: "FK_Associations_Products_ProductId",
                table: "Associations");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Products_ProductId",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Associations",
                table: "Associations");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.RenameTable(
                name: "Associations",
                newName: "Association");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_ProductId",
                table: "Category",
                newName: "IX_Category_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Associations_ProductId",
                table: "Association",
                newName: "IX_Association_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Associations_CategoryId",
                table: "Association",
                newName: "IX_Association_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Association",
                table: "Association",
                column: "AssociationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Association_Category_CategoryId",
                table: "Association",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Association_Products_ProductId",
                table: "Association",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Products_ProductId",
                table: "Category",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
