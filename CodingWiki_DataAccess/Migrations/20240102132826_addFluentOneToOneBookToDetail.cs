using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingWiki_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addFluentOneToOneBookToDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_fluent_Fluent_BookDetails_BookDetail_Id",
                table: "Book_fluent");

            migrationBuilder.DropIndex(
                name: "IX_Book_fluent_BookDetail_Id",
                table: "Book_fluent");

            migrationBuilder.DropColumn(
                name: "BookDetail_Id",
                table: "Book_fluent");

            migrationBuilder.AddColumn<int>(
                name: "Book_Id",
                table: "Fluent_BookDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Fluent_BookDetails_Book_Id",
                table: "Fluent_BookDetails",
                column: "Book_Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_BookDetails_Book_fluent_Book_Id",
                table: "Fluent_BookDetails",
                column: "Book_Id",
                principalTable: "Book_fluent",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_BookDetails_Book_fluent_Book_Id",
                table: "Fluent_BookDetails");

            migrationBuilder.DropIndex(
                name: "IX_Fluent_BookDetails_Book_Id",
                table: "Fluent_BookDetails");

            migrationBuilder.DropColumn(
                name: "Book_Id",
                table: "Fluent_BookDetails");

            migrationBuilder.AddColumn<int>(
                name: "BookDetail_Id",
                table: "Book_fluent",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Book_fluent_BookDetail_Id",
                table: "Book_fluent",
                column: "BookDetail_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_fluent_Fluent_BookDetails_BookDetail_Id",
                table: "Book_fluent",
                column: "BookDetail_Id",
                principalTable: "Fluent_BookDetails",
                principalColumn: "BookDetail_Id");
        }
    }
}
