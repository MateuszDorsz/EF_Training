using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingWiki_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addFluentBookDetailKeyAndRequirements : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBook_Authors_AuthorsAuthor_Id",
                table: "AuthorBook");

            migrationBuilder.RenameColumn(
                name: "AuthorsAuthor_Id",
                table: "AuthorBook",
                newName: "Author_Id");

            migrationBuilder.CreateTable(
                name: "Fluent_BookDetails",
                columns: table => new
                {
                    BookDetail_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoOfChapters = table.Column<int>(type: "int", nullable: false),
                    NumberOfPages = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fluent_BookDetails", x => x.BookDetail_Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBook_Authors_Author_Id",
                table: "AuthorBook",
                column: "Author_Id",
                principalTable: "Authors",
                principalColumn: "Author_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBook_Authors_Author_Id",
                table: "AuthorBook");

            migrationBuilder.DropTable(
                name: "Fluent_BookDetails");

            migrationBuilder.RenameColumn(
                name: "Author_Id",
                table: "AuthorBook",
                newName: "AuthorsAuthor_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBook_Authors_AuthorsAuthor_Id",
                table: "AuthorBook",
                column: "AuthorsAuthor_Id",
                principalTable: "Authors",
                principalColumn: "Author_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
