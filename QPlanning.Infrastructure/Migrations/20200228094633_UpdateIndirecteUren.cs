using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QPlanning.Infrastructure.Migrations
{
    public partial class UpdateIndirecteUren : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "01f70b94-b833-472b-a60a-6a773756dd0d", "AQAAAAEAACcQAAAAED3k6w+NMyN/LlMmgeUEsOy2o0nUkorTG91k+WH++4UfV+6Wcms9LQZsBn0e1D8yog==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "155fd849-9275-48ba-b2f2-92c44eadd79a", "AQAAAAEAACcQAAAAEGZ9InH/HLyJkznqflFM3ZdKbAq8/xSycHgirOcKfwt44V2vyrq2NS67Nu915PQ+3w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f4016cc5-f84e-4419-a159-5a565e71a3fd", "AQAAAAEAACcQAAAAEG1M4HVokLEQu7ZA+maRSTX2PVKAq+yhlAsDMRaNpnyDuFsoHg4B+AEdhPq5AintqA==" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "IndirecteUren",
                keyColumn: "Id",
                keyValue: 5,
                column: "Omschrijving",
                value: "Regulier verlof");

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "IndirecteUren",
                columns: new[] { "Id", "Created", "CreatedBy", "IsActief", "Modified", "ModifiedBy", "Omschrijving" },
                values: new object[] { 8, new DateTime(2019, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "RM", true, new DateTime(2019, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "RM", "Vaktechniek" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "IndirecteUren",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fe269abb-4fe0-472b-86fd-df72ea1c1b3f", "AQAAAAEAACcQAAAAEKJ/FtPC/HBzXeUeYmNIcugWQFE6DkSPGvJTZYoIwEj68s/WdFy3OaAhopKKBln5Rw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "cfbee974-3c89-4fd7-8b65-eae78224335a", "AQAAAAEAACcQAAAAEDXF0tRp+bXFzMjv8nTY9KHKf9PrzYHTCyUC4Z4AOH4tDLnls69jsJFk8JleqP19Gg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f4c767cb-e3e6-4847-b7a7-99ba00bedb98", "AQAAAAEAACcQAAAAELu3AgegeRhpwX2CnxlY4szwU/vE7xzU+Ja24WmcEwCFPX0QpFxNCBmYWer8GCbMkA==" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "IndirecteUren",
                keyColumn: "Id",
                keyValue: 5,
                column: "Omschrijving",
                value: "Verlof");
        }
    }
}
