using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QPlanning.Infrastructure.Migrations
{
    public partial class DefaultitemsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0fcdd0b3-dc2b-4f79-981e-8f7152ac26cd", "AQAAAAEAACcQAAAAEDELhpUdf8QM2Dfv7l/Gh153/Gx21My+tUlMI4mTcMgp0npWDY7rflWTL5sOGzS1/w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "da8c5883-b568-4be8-80ab-474f2b222f3b", "AQAAAAEAACcQAAAAEBuSOW/KikHbYho2WMKPLfo1463l1j+voqc7MABOIoQSPaCJxwrYEy88E9CSopr7VA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3deeaea4-ed32-46fa-8863-fba9f02619ba", "AQAAAAEAACcQAAAAEAd3dA2gPMuLSRqVaORpg6lDUIokY4fVWuBcgAjMYuRdhJaGIspaja7IoaWtf+BWzw==" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "IndirecteUren",
                columns: new[] { "Id", "Created", "CreatedBy", "IsActief", "Modified", "ModifiedBy", "Omschrijving" },
                values: new object[,]
                {
                    { 9, new DateTime(2019, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "RM", true, new DateTime(2019, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "RM", "Macrom" },
                    { 10, new DateTime(2019, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "RM", true, new DateTime(2019, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "RM", "Zwangerschapsverlof" },
                    { 11, new DateTime(2019, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "RM", true, new DateTime(2019, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "RM", "QAS" },
                    { 12, new DateTime(2019, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "RM", true, new DateTime(2019, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "RM", "Nog niet in dienst" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Team",
                columns: new[] { "Id", "Created", "CreatedBy", "IsActief", "Modified", "ModifiedBy", "Naam" },
                values: new object[,]
                {
                    { 5, new DateTime(2019, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "RM", true, new DateTime(2019, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "RM", "Arnhem" },
                    { 6, new DateTime(2019, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "RM", true, new DateTime(2019, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "RM", "Amsterdam" },
                    { 7, new DateTime(2019, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "RM", true, new DateTime(2019, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "RM", "Woco" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "IndirecteUren",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "IndirecteUren",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "IndirecteUren",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "IndirecteUren",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Team",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Team",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Team",
                keyColumn: "Id",
                keyValue: 7);

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
        }
    }
}
