using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdoptPetProject.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Categories_catIdid",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_catIdid",
                table: "Pets");

            migrationBuilder.RenameColumn(
                name: "catIdid",
                table: "Pets",
                newName: "catId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "catId",
                table: "Pets",
                newName: "catIdid");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_catIdid",
                table: "Pets",
                column: "catIdid");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Categories_catIdid",
                table: "Pets",
                column: "catIdid",
                principalTable: "Categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
