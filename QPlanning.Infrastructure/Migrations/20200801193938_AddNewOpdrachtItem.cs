using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QPlanning.Infrastructure.Migrations
{
    public partial class AddNewOpdrachtItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Opdracht",
                keyColumn: "Id",
                keyValue: 4,
                column: "Omschrijving",
                value: "Bijzondere verklaringen");

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Opdracht",
                columns: new[] { "Id", "Created", "CreatedBy", "IsActief", "Modified", "ModifiedBy", "Omschrijving" },
                values: new object[] { 5, new DateTime(2019, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "RM", true, new DateTime(2019, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "RM", "Overig" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Opdracht",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d628ab5a-395b-4500-b806-501f07310100", "AQAAAAEAACcQAAAAEHwEvlT44RIL8B89JmAZNyOES7vxDVD8kluH3ePcc7HiLC0u+hKHPLinXQtcJRqhCQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9f641c22-7856-4e70-b8bf-40f5a44c500d", "AQAAAAEAACcQAAAAEMQD+FTgoOTrK7CvuehCbO2Nn2pJefV6OhWdyuOwJk6TjW/gLh0VyIoA/uzPzk7h4g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "75a39337-8970-4aeb-9ffd-54e664aaa088", "AQAAAAEAACcQAAAAEC6I+Wsa94sFEzVN58sPPpCGTXTDctWd6YdEtJj/xGt368sdbUVW2P3V5Z3Saw8WPw==" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Opdracht",
                keyColumn: "Id",
                keyValue: 4,
                column: "Omschrijving",
                value: "Overig");
        }
    }
}
