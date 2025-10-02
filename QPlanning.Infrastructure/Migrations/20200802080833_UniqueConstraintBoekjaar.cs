using Microsoft.EntityFrameworkCore.Migrations;

namespace QPlanning.Infrastructure.Migrations
{
    public partial class UniqueConstraintBoekjaar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Boekjaar_KlantId",
                schema: "dbo",
                table: "Boekjaar");

            migrationBuilder.AddUniqueConstraint(
                name: "IX_UniqueConstraint_KlantId_Jaar",
                schema: "dbo",
                table: "Boekjaar",
                columns: new[] { "KlantId", "Jaar" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "074cca2d-7be9-42c3-8412-acd5017536b9", "AQAAAAEAACcQAAAAEBv3RzLqfUpe7/O2hI8QJRs+Sxt+tr4P5jTsFXxJXcHwtRxBQu8CocrFHS+vUCHzdA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1fb0a84a-c9a6-4582-877c-54366ecb0942", "AQAAAAEAACcQAAAAEEHxwQYe6h199Vq7Oorc0Em79UL/MmFGwZM/0AAMc8KiIcn6rVQ9eOPs6jBeWaSSyQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d321f4fa-a5e2-45c5-b5ee-cfe3e0b44f57", "AQAAAAEAACcQAAAAEA9eSqYlFuko7bvvMN8l/kD9aauOvhFGznIlXDzw1k4gJN6hnPn8n+ma4DcekakwUw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "IX_UniqueConstraint_KlantId_Jaar",
                schema: "dbo",
                table: "Boekjaar");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "33353980-3ece-40f0-b8ac-b67340dd164b", "AQAAAAEAACcQAAAAELnbbLbZPeKdo3tBRZtOAVvKl0/OPHid95E/dBYsfOjPtXV1nQXCSVGr/Q2pDQSOog==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "17c3cae9-3825-4067-a527-706e800e9e56", "AQAAAAEAACcQAAAAEBLp3ZauLrLW8L1E9TRkfoWNKeO0S2d3gtR68liM3018E/fuvAUyPXVGYi8ggpWqtw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "91797c26-602f-4865-b912-2b1cd75f863b", "AQAAAAEAACcQAAAAEM9QxTLu/z4jWf0KPt9jygvZtRpKik1QB88sMz+ZicjeIMcHQdlLkfTzqac3tDzqSA==" });

            migrationBuilder.CreateIndex(
                name: "IX_Boekjaar_KlantId",
                schema: "dbo",
                table: "Boekjaar",
                column: "KlantId");
        }
    }
}
