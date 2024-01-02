using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingWiki_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addFluentBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Book_fluent",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISBN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BookDetail_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book_fluent", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Book_fluent_Fluent_BookDetails_BookDetail_Id",
                        column: x => x.BookDetail_Id,
                        principalTable: "Fluent_BookDetails",
                        principalColumn: "BookDetail_Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_fluent_BookDetail_Id",
                table: "Book_fluent",
                column: "BookDetail_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book_fluent");
        }
    }
}
