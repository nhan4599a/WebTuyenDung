using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebTuyenDung.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 4, 28, 8, 53, 4, 75, DateTimeKind.Unspecified).AddTicks(3546), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 4, 28, 8, 53, 4, 75, DateTimeKind.Unspecified).AddTicks(3548), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 4, 28, 8, 53, 4, 75, DateTimeKind.Unspecified).AddTicks(3549), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RecruimentNews",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 4, 28, 8, 53, 4, 75, DateTimeKind.Unspecified).AddTicks(2032), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RecruimentNews",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 4, 28, 8, 53, 4, 75, DateTimeKind.Unspecified).AddTicks(2035), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RecruimentNews",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 4, 28, 8, 53, 4, 75, DateTimeKind.Unspecified).AddTicks(2035), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RecruimentNews",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 4, 28, 8, 53, 4, 75, DateTimeKind.Unspecified).AddTicks(2036), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RecruimentNews",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 4, 28, 8, 53, 4, 75, DateTimeKind.Unspecified).AddTicks(2037), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RecruimentNews",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 4, 28, 8, 53, 4, 75, DateTimeKind.Unspecified).AddTicks(2038), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RecruimentNews",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 4, 28, 8, 53, 4, 75, DateTimeKind.Unspecified).AddTicks(2038), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RecruimentNews",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 4, 28, 8, 53, 4, 75, DateTimeKind.Unspecified).AddTicks(2039), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RecruimentNews",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 4, 28, 8, 53, 4, 75, DateTimeKind.Unspecified).AddTicks(2040), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHashed" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 4, 28, 8, 53, 4, 75, DateTimeKind.Unspecified).AddTicks(793), new TimeSpan(0, 7, 0, 0, 0)), "ADAAAF16012951A6F84930B255397DE300A21BE67134CA88C4A055B2CB0A53F4" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PasswordHashed" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 4, 28, 8, 53, 4, 75, DateTimeKind.Unspecified).AddTicks(702), new TimeSpan(0, 7, 0, 0, 0)), "0E9DB51810539883943E5599C9824A07985B6078261CCE78E7F876A5C155961C" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PasswordHashed" },
                values: new object[] { new DateTimeOffset(new DateTime(2023, 4, 28, 8, 53, 4, 75, DateTimeKind.Unspecified).AddTicks(174), new TimeSpan(0, 7, 0, 0, 0)), "ADAAAF16012951A6F84930B255397DE300A21BE67134CA88C4A055B2CB0A53F4" });
        }
    }
}
