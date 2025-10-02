using Microsoft.EntityFrameworkCore.Migrations;

namespace QPlanning.Infrastructure.Migrations
{
    public partial class MedewerkerPlanbaarDoorTeamsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedewerkerPlanbaarDoorTeams",
                schema: "dbo",
                columns: table => new
                {
                    MedewerkerId = table.Column<int>(nullable: false),
                    TeamId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedewerkerPlanbaarDoorTeams", x => new { x.MedewerkerId, x.TeamId });
                    table.ForeignKey(
                        name: "FK_MedewerkerPlanbaarDoorTeams_Medewerker_MedewerkerId",
                        column: x => x.MedewerkerId,
                        principalSchema: "dbo",
                        principalTable: "Medewerker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedewerkerPlanbaarDoorTeams_Team_TeamId",
                        column: x => x.TeamId,
                        principalSchema: "dbo",
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6995be29-a620-4b8e-b747-7adc6e1668f8", "AQAAAAEAACcQAAAAEAMxzTHy6Yk43Qsq/eNN9ZfpeS9x0AnBd9mVx/C7fZI6nXPA/4d9tMDMkIr5yhc1Qw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e9adb3e8-dbe5-4d45-b9f4-a7ae1363cfda", "AQAAAAEAACcQAAAAEIdJezzfi9I1zTaSo3d2FKL5tWgbM5bFyvnw8iVC3AQe31nBbKXXsTyC3tCccPnfeQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "788d3858-8bbf-43ac-a84b-8239f15b69e2", "AQAAAAEAACcQAAAAEEVR1mH/PZO2VVyHnlgS+6pkNoCHGeT5d9bwhYAp8D7jSslUHvPlkOsd//6ItI76uQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_MedewerkerPlanbaarDoorTeams_TeamId",
                schema: "dbo",
                table: "MedewerkerPlanbaarDoorTeams",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedewerkerPlanbaarDoorTeams",
                schema: "dbo");

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
        }
    }
}
