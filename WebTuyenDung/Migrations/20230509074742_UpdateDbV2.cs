using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebTuyenDung.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDbV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 5, 9, 14, 29, 48, 920, DateTimeKind.Unspecified).AddTicks(5972), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 5, 9, 14, 29, 48, 920, DateTimeKind.Unspecified).AddTicks(5981), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 5, 9, 14, 29, 48, 920, DateTimeKind.Unspecified).AddTicks(5983), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RecruimentNews",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 5, 9, 14, 29, 48, 920, DateTimeKind.Unspecified).AddTicks(2519), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RecruimentNews",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 5, 9, 14, 29, 48, 920, DateTimeKind.Unspecified).AddTicks(2531), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RecruimentNews",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 5, 9, 14, 29, 48, 920, DateTimeKind.Unspecified).AddTicks(2534), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RecruimentNews",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 5, 9, 14, 29, 48, 920, DateTimeKind.Unspecified).AddTicks(2536), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RecruimentNews",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 5, 9, 14, 29, 48, 920, DateTimeKind.Unspecified).AddTicks(2538), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RecruimentNews",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 5, 9, 14, 29, 48, 920, DateTimeKind.Unspecified).AddTicks(2539), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RecruimentNews",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 5, 9, 14, 29, 48, 920, DateTimeKind.Unspecified).AddTicks(2541), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RecruimentNews",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 5, 9, 14, 29, 48, 920, DateTimeKind.Unspecified).AddTicks(2543), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RecruimentNews",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 5, 9, 14, 29, 48, 920, DateTimeKind.Unspecified).AddTicks(2544), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHashed" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 5, 9, 14, 29, 48, 919, DateTimeKind.Unspecified).AddTicks(8787), new TimeSpan(0, 7, 0, 0, 0)), "3a724d950058dc18bd63d7769503f3f3418a28a4e6735fded0043f2b453b9e19" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHashed" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 5, 9, 14, 29, 48, 919, DateTimeKind.Unspecified).AddTicks(8280), new TimeSpan(0, 7, 0, 0, 0)), "3a724d950058dc18bd63d7769503f3f3418a28a4e6735fded0043f2b453b9e19" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHashed" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 5, 9, 14, 29, 48, 919, DateTimeKind.Unspecified).AddTicks(7146), new TimeSpan(0, 7, 0, 0, 0)), "3a724d950058dc18bd63d7769503f3f3418a28a4e6735fded0043f2b453b9e19" });
        }
    }
}
