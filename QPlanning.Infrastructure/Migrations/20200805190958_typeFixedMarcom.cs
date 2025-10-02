using Microsoft.EntityFrameworkCore.Migrations;

namespace QPlanning.Infrastructure.Migrations
{
    public partial class typeFixedMarcom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6b1dc76e-5872-40e8-a2e9-bf81ca9b82bb", "AQAAAAEAACcQAAAAEFLk/jbRanroLMj0JdLgO1usDucHj2/PHUovehDtoT9wnkjhCvvHriq0EAehn8prXw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0b8f5b13-f6ef-469d-9522-7a7662fbeec6", "AQAAAAEAACcQAAAAELLsv1pavRLmyo1M9I7d9j0KIsGVZOtGGcbbS+6nicVZa3Ai+6Q/DjP021tpK0Y2AA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5a1e7c63-ea86-4c86-b371-c5465c9f8fdb", "AQAAAAEAACcQAAAAEP456Am6wT/cZGveWEJQsHhJXbYNwJwtV05odPoxSY1uUjr250rjsnV51+9+mYppWw==" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "IndirecteUren",
                keyColumn: "Id",
                keyValue: 9,
                column: "Omschrijving",
                value: "Marcom");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "20ac5a69-d0c4-442b-8237-d90a2b7353dd", "AQAAAAEAACcQAAAAEE2/GUFVpw2UH1V0BHj1TYDlaQYLI1NsqfE+21297ZGCj71sgds/FIdgWVu+ADXuwA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e38f22b4-22a1-4a7d-ac38-0ece612e8ba8", "AQAAAAEAACcQAAAAECPm+47H2ajX2PxYM1JRHl6FuDyuF1Gu1oNA51v9L2JlAANFkuM4Mjq8GggRC21mrg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e1099721-6f66-47b0-9dd8-ce5fcb96d0f9", "AQAAAAEAACcQAAAAEGQJluSEYr4qYYD22uinmfPJGUWtowMXZj3GnUR2t9TPAS0osSQsk2zPDw38bugOkg==" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "IndirecteUren",
                keyColumn: "Id",
                keyValue: 9,
                column: "Omschrijving",
                value: "Macrom");
        }
    }
}
