using Microsoft.EntityFrameworkCore.Migrations;

namespace QPlanning.Infrastructure.Migrations
{
    public partial class correctSpelling : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "76259dc1-3249-4575-8383-b51080a86678", "AQAAAAEAACcQAAAAEFESN0Cz+aW9167IZhdWmG6MwvYdZyxSY7JbKYbvbbIOaOGSmZx8KVEuzAO6S/uypA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b4c15631-e1ce-4c0e-a33e-6ce01281858d", "AQAAAAEAACcQAAAAEDPIaBs4OzfgIvJptqFyUNmLmG06NtFnmNDBgXWwKzFfqK6qry7vvLaHEjrROzKMpw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "47040bbb-46ac-48eb-b888-e9ec1f8e6869", "AQAAAAEAACcQAAAAEA9J2I7Sv/My+SLZQBuJTA5a0a8hWeU0YEKfBxG7i0MTzxLlB+qRWRdIkskFh1bFog==" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MedewerkerFunctie",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Beschrijving", "DisplayName", "TechnischeNaam" },
                values: new object[] { "Deze persoon heeft de functie Associate", "Associate", "Associate" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Opdracht",
                keyColumn: "Id",
                keyValue: 1,
                column: "Omschrijving",
                value: "Interim");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                table: "MedewerkerFunctie",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Beschrijving", "DisplayName", "TechnischeNaam" },
                values: new object[] { "Deze persoon heeft de functie Assosiatie", "Assosiatie", "Assosiatie" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Opdracht",
                keyColumn: "Id",
                keyValue: 1,
                column: "Omschrijving",
                value: "Interem");
        }
    }
}
