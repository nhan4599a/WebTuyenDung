using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebTuyenDung.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePasswordV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 5, 9, 15, 9, 26, 389, DateTimeKind.Unspecified).AddTicks(9916), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 5, 9, 15, 9, 26, 389, DateTimeKind.Unspecified).AddTicks(9939), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 5, 9, 15, 9, 26, 389, DateTimeKind.Unspecified).AddTicks(9941), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RecruimentNews",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 5, 9, 15, 9, 26, 389, DateTimeKind.Unspecified).AddTicks(5393), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RecruimentNews",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 5, 9, 15, 9, 26, 389, DateTimeKind.Unspecified).AddTicks(5426), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RecruimentNews",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 5, 9, 15, 9, 26, 389, DateTimeKind.Unspecified).AddTicks(5430), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RecruimentNews",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 5, 9, 15, 9, 26, 389, DateTimeKind.Unspecified).AddTicks(5434), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RecruimentNews",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 5, 9, 15, 9, 26, 389, DateTimeKind.Unspecified).AddTicks(5436), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RecruimentNews",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 5, 9, 15, 9, 26, 389, DateTimeKind.Unspecified).AddTicks(5439), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RecruimentNews",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 5, 9, 15, 9, 26, 389, DateTimeKind.Unspecified).AddTicks(5441), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RecruimentNews",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 5, 9, 15, 9, 26, 389, DateTimeKind.Unspecified).AddTicks(5444), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RecruimentNews",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 5, 9, 15, 9, 26, 389, DateTimeKind.Unspecified).AddTicks(5446), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHashed" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 5, 9, 15, 9, 26, 389, DateTimeKind.Unspecified).AddTicks(579), new TimeSpan(0, 7, 0, 0, 0)), "1CF58803332D6154476FE4D4710F26F1569196FF2097F677A01189B1A7DACAFF" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHashed" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 5, 9, 15, 9, 26, 389, DateTimeKind.Unspecified).AddTicks(195), new TimeSpan(0, 7, 0, 0, 0)), "1CF58803332D6154476FE4D4710F26F1569196FF2097F677A01189B1A7DACAFF" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHashed" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 5, 9, 15, 9, 26, 388, DateTimeKind.Unspecified).AddTicks(8667), new TimeSpan(0, 7, 0, 0, 0)), "1CF58803332D6154476FE4D4710F26F1569196FF2097F677A01189B1A7DACAFF" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 5, 9, 14, 47, 13, 282, DateTimeKind.Unspecified).AddTicks(3068), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 5, 9, 14, 47, 13, 282, DateTimeKind.Unspecified).AddTicks(3074), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 5, 9, 14, 47, 13, 282, DateTimeKind.Unspecified).AddTicks(3076), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RecruimentNews",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 5, 9, 14, 47, 13, 281, DateTimeKind.Unspecified).AddTicks(9187), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RecruimentNews",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 5, 9, 14, 47, 13, 281, DateTimeKind.Unspecified).AddTicks(9205), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RecruimentNews",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 5, 9, 14, 47, 13, 281, DateTimeKind.Unspecified).AddTicks(9207), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RecruimentNews",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 5, 9, 14, 47, 13, 281, DateTimeKind.Unspecified).AddTicks(9209), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RecruimentNews",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 5, 9, 14, 47, 13, 281, DateTimeKind.Unspecified).AddTicks(9212), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RecruimentNews",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 5, 9, 14, 47, 13, 281, DateTimeKind.Unspecified).AddTicks(9214), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RecruimentNews",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 5, 9, 14, 47, 13, 281, DateTimeKind.Unspecified).AddTicks(9216), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RecruimentNews",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 5, 9, 14, 47, 13, 281, DateTimeKind.Unspecified).AddTicks(9218), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RecruimentNews",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 5, 9, 14, 47, 13, 281, DateTimeKind.Unspecified).AddTicks(9220), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHashed" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 5, 9, 14, 47, 13, 281, DateTimeKind.Unspecified).AddTicks(5138), new TimeSpan(0, 7, 0, 0, 0)), "1cf58803332d6154476fe4d4710f26f1569196ff2097f677a01189b1a7dacaff" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHashed" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 5, 9, 14, 47, 13, 281, DateTimeKind.Unspecified).AddTicks(4709), new TimeSpan(0, 7, 0, 0, 0)), "1cf58803332d6154476fe4d4710f26f1569196ff2097f677a01189b1a7dacaff" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHashed" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 5, 9, 14, 47, 13, 281, DateTimeKind.Unspecified).AddTicks(3398), new TimeSpan(0, 7, 0, 0, 0)), "1cf58803332d6154476fe4d4710f26f1569196ff2097f677a01189b1a7dacaff" });
        }
    }
}
