using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChefsDishes.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Chefs_ChefID",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "Chef",
                table: "Dishes");

            migrationBuilder.RenameColumn(
                name: "ChefID",
                table: "Dishes",
                newName: "ChefId");

            migrationBuilder.RenameIndex(
                name: "IX_Dishes_ChefID",
                table: "Dishes",
                newName: "IX_Dishes_ChefId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Chefs_ChefId",
                table: "Dishes",
                column: "ChefId",
                principalTable: "Chefs",
                principalColumn: "ChefId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Chefs_ChefId",
                table: "Dishes");

            migrationBuilder.RenameColumn(
                name: "ChefId",
                table: "Dishes",
                newName: "ChefID");

            migrationBuilder.RenameIndex(
                name: "IX_Dishes_ChefId",
                table: "Dishes",
                newName: "IX_Dishes_ChefID");

            migrationBuilder.AddColumn<string>(
                name: "Chef",
                table: "Dishes",
                type: "varchar(45)",
                maxLength: 45,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Chefs_ChefID",
                table: "Dishes",
                column: "ChefID",
                principalTable: "Chefs",
                principalColumn: "ChefId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
