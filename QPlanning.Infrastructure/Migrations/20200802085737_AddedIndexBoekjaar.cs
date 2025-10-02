using Microsoft.EntityFrameworkCore.Migrations;

namespace QPlanning.Infrastructure.Migrations
{
    public partial class AddedIndexBoekjaar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_NonClustered_KlantId_Jaar",
                schema: "dbo",
                table: "Boekjaar",
                columns: new[] { "KlantId", "Jaar" },
                unique: true)
                .Annotation("SqlServer:Clustered", false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_NonClustered_KlantId_Jaar",
                schema: "dbo",
                table: "Boekjaar");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "837f275e-26a7-40ec-b44d-cb8b6f6d7d08", "AQAAAAEAACcQAAAAEGxgvicKnkJcsu6aH8ud5uGIHn63QbxSxidmHfB21SnCvPyJIvSuCA/V+aNaPcdURQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b5f52609-f162-4bbe-b1dc-dbc67c6b6f13", "AQAAAAEAACcQAAAAEIC4pazG7M5e/QKoi1yaYqWoonT66hTPMAJC9xC304ex6D/z7YT5bQA1ioa28oBf5g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "03ad90be-478b-4375-8200-a617930a0004", "AQAAAAEAACcQAAAAELYqlY2no2rUFFlX9ycnxs2orhHgN25id2crVnLceOBWpjohSjdlamY6URciL4ljzQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_NonClustered_KlantId_Jaar",
                schema: "dbo",
                table: "Boekjaar",
                columns: new[] { "KlantId", "Jaar" },
                unique: true);
        }
    }
}
