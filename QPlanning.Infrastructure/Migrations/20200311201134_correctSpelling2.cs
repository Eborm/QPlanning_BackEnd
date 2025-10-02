using Microsoft.EntityFrameworkCore.Migrations;

namespace QPlanning.Infrastructure.Migrations
{
    public partial class correctSpelling2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "30b346b4-b93e-42e1-9af7-bf5b7a6d2778", "AQAAAAEAACcQAAAAEB1NcsZdoshbCzuas37VG8Y9wIeOdVxAbd4aUGLXbHycna7V3UPNov5o3zfoY9r0LQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a4eac9e1-18b8-4a88-999e-1fe105ab4725", "AQAAAAEAACcQAAAAEMJ5Z3A8TzO/EOBb4o3MONAq/hCQPoaNSMbXgymPi2kjiaqZ/w7iO+/s8hF7SxbMXQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a677fd0a-f312-424f-90fc-c2af49745d1d", "AQAAAAEAACcQAAAAEAMLZGpyohOOOqXgNMRrX5on8nt6qE1JBYO8x4KNfj6NkCkzYEDrHHz92w+P3YF/2Q==" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "MedewerkerFunctie",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Beschrijving", "DisplayName", "TechnischeNaam" },
                values: new object[] { "Deze persoon heeft de functie Senior associate", "Senior associate", "SeniorAssociate" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                keyValue: 4,
                columns: new[] { "Beschrijving", "DisplayName", "TechnischeNaam" },
                values: new object[] { "Deze persoon heeft de functie SeniorAssosiate", "Senior assosiate", "SeniorAssosiate" });
        }
    }
}
