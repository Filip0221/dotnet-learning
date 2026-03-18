using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab5.Migrations
{
    public partial class AddGenresAndLinkToMovies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // 1. Tworzymy tabelę Genres
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            // Opcjonalnie: dodanie domyślnego gatunku "unknown"
            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "unknown" }
            );

            // 2. Dodajemy kolumnę GenreId do istniejącej tabeli Movies
            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "Movies",
                type: "INTEGER",
                nullable: false,
                defaultValue: 1);

            // 3. Tworzymy indeks
            migrationBuilder.CreateIndex(
                name: "IX_Movies_GenreId",
                table: "Movies",
                column: "GenreId");

            // 4. Dodajemy klucz obcy
            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Genres_GenreId",
                table: "Movies",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Cofamy zmiany
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Genres_GenreId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_GenreId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "Movies");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}