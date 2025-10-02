using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QPlanning.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _20250821_1245_FixedDynamicsInCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Achternaam", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Voornaam" },
                values: new object[] { 1, 0, "Mengelers", "9a8ec910-53b7-43b0-8c8c-47786aa78585", "roy.mengelers@zuyd.nl", true, false, null, "roy.mengelers@zuyd.nl", "roy.mengelers@zuyd.nl", "AQAAAAIAAYagAAAAENIPRPI6RPXmc6QcvIvvQlA6xjA3dGU6Dm/Elj4QWeoVRjvf9MeFb7RQpHCYNv1Zlg==", null, false, "", false, "roy.mengelers@zuyd.nl", "Roy" });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[] { 1, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Admin", 1 });
        }
    }
}
