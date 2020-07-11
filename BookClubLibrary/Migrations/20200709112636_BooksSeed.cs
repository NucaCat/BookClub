using Microsoft.EntityFrameworkCore.Migrations;

namespace BookClubLibrary.Migrations
{
    public partial class BooksSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "BookName" },
                values: new object[,]
                {
                    { 1, "Преступление и наказание" },
                    { 2, "Мастер и Маргарита" },
                    { 3, "Война и Мир" },
                    { 4, "Дубровский" },
                    { 5, "Анна Каренина" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
