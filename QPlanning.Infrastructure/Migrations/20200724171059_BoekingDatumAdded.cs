using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QPlanning.Infrastructure.Migrations
{
    public partial class BoekingDatumAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Datum",
                schema: "dbo",
                table: "Boeking",
                nullable: false,
                defaultValueSql: "getdate()");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Datum",
                schema: "dbo",
                table: "Boeking");

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
        }
    }
}
