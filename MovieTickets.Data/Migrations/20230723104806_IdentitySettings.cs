using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieTickets.Data.Migrations
{
    public partial class IdentitySettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 8, 2, 13, 48, 6, 309, DateTimeKind.Local).AddTicks(6007), new DateTime(2023, 7, 13, 13, 48, 6, 309, DateTimeKind.Local).AddTicks(5974) });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 7, 26, 13, 48, 6, 309, DateTimeKind.Local).AddTicks(6016), new DateTime(2023, 7, 23, 13, 48, 6, 309, DateTimeKind.Local).AddTicks(6014) });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 7, 30, 13, 48, 6, 309, DateTimeKind.Local).AddTicks(6022), new DateTime(2023, 7, 23, 13, 48, 6, 309, DateTimeKind.Local).AddTicks(6020) });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 7, 18, 13, 48, 6, 309, DateTimeKind.Local).AddTicks(6028), new DateTime(2023, 7, 13, 13, 48, 6, 309, DateTimeKind.Local).AddTicks(6025) });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 7, 21, 13, 48, 6, 309, DateTimeKind.Local).AddTicks(6033), new DateTime(2023, 7, 13, 13, 48, 6, 309, DateTimeKind.Local).AddTicks(6031) });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 8, 12, 13, 48, 6, 309, DateTimeKind.Local).AddTicks(6040), new DateTime(2023, 7, 26, 13, 48, 6, 309, DateTimeKind.Local).AddTicks(6038) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 7, 28, 19, 45, 56, 509, DateTimeKind.Local).AddTicks(7224), new DateTime(2023, 7, 8, 19, 45, 56, 509, DateTimeKind.Local).AddTicks(7180) });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 7, 21, 19, 45, 56, 509, DateTimeKind.Local).AddTicks(7237), new DateTime(2023, 7, 18, 19, 45, 56, 509, DateTimeKind.Local).AddTicks(7234) });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 7, 25, 19, 45, 56, 509, DateTimeKind.Local).AddTicks(7246), new DateTime(2023, 7, 18, 19, 45, 56, 509, DateTimeKind.Local).AddTicks(7243) });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 7, 13, 19, 45, 56, 509, DateTimeKind.Local).AddTicks(7255), new DateTime(2023, 7, 8, 19, 45, 56, 509, DateTimeKind.Local).AddTicks(7251) });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 7, 16, 19, 45, 56, 509, DateTimeKind.Local).AddTicks(7262), new DateTime(2023, 7, 8, 19, 45, 56, 509, DateTimeKind.Local).AddTicks(7260) });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 8, 7, 19, 45, 56, 509, DateTimeKind.Local).AddTicks(7272), new DateTime(2023, 7, 21, 19, 45, 56, 509, DateTimeKind.Local).AddTicks(7269) });
        }
    }
}
