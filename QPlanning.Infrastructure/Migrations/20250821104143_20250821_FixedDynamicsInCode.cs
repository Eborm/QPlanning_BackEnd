using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QPlanning.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _20250821_FixedDynamicsInCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9a8ec910-53b7-43b0-8c8c-47786aa78585", "AQAAAAIAAYagAAAAENIPRPI6RPXmc6QcvIvvQlA6xjA3dGU6Dm/Elj4QWeoVRjvf9MeFb7RQpHCYNv1Zlg==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6b1dc76e-5872-40e8-a2e9-bf81ca9b82bb", "AQAAAAEAACcQAAAAEFLk/jbRanroLMj0JdLgO1usDucHj2/PHUovehDtoT9wnkjhCvvHriq0EAehn8prXw==" });
        }
    }
}
