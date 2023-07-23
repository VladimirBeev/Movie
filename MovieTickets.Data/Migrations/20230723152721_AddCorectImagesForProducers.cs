using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieTickets.Data.Migrations
{
    public partial class AddCorectImagesForProducers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 8, 2, 18, 27, 20, 698, DateTimeKind.Local).AddTicks(3771), new DateTime(2023, 7, 13, 18, 27, 20, 698, DateTimeKind.Local).AddTicks(3733) });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 7, 26, 18, 27, 20, 698, DateTimeKind.Local).AddTicks(3781), new DateTime(2023, 7, 23, 18, 27, 20, 698, DateTimeKind.Local).AddTicks(3778) });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 7, 30, 18, 27, 20, 698, DateTimeKind.Local).AddTicks(3787), new DateTime(2023, 7, 23, 18, 27, 20, 698, DateTimeKind.Local).AddTicks(3785) });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 7, 18, 18, 27, 20, 698, DateTimeKind.Local).AddTicks(3794), new DateTime(2023, 7, 13, 18, 27, 20, 698, DateTimeKind.Local).AddTicks(3791) });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 7, 21, 18, 27, 20, 698, DateTimeKind.Local).AddTicks(3799), new DateTime(2023, 7, 13, 18, 27, 20, 698, DateTimeKind.Local).AddTicks(3797) });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 8, 12, 18, 27, 20, 698, DateTimeKind.Local).AddTicks(3810), new DateTime(2023, 7, 26, 18, 27, 20, 698, DateTimeKind.Local).AddTicks(3808) });

            migrationBuilder.UpdateData(
                table: "Producers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "http://dotnethow.net/images/producers/producer-1.jpeg");

            migrationBuilder.UpdateData(
                table: "Producers",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "http://dotnethow.net/images/producers/producer-2.jpeg");

            migrationBuilder.UpdateData(
                table: "Producers",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "http://dotnethow.net/images/producers/producer-3.jpeg");

            migrationBuilder.UpdateData(
                table: "Producers",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "http://dotnethow.net/images/producers/producer-4.jpeg");

            migrationBuilder.UpdateData(
                table: "Producers",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "http://dotnethow.net/images/producers/producer-5.jpeg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "Producers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "http://dotnethow.net/images.producers/producer-1.jpeg");

            migrationBuilder.UpdateData(
                table: "Producers",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "http://dotnethow.net/images.producers/producer-2.jpeg");

            migrationBuilder.UpdateData(
                table: "Producers",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "http://dotnethow.net/images.producers/producer-3.jpeg");

            migrationBuilder.UpdateData(
                table: "Producers",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "http://dotnethow.net/images.producers/producer-4.jpeg");

            migrationBuilder.UpdateData(
                table: "Producers",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "http://dotnethow.net/images.producers/producer-5.jpeg");
        }
    }
}
