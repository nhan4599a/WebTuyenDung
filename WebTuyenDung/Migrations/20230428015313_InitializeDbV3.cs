using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebTuyenDung.Migrations
{
    /// <inheritdoc />
    public partial class InitializeDbV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Benefit",
                table: "RecruimentNews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
                columns: new[] { "Benefit", "CreatedAt" },
                values: new object[] { "<ul><li>Bảo hiểm xã hội full lương</li><li>Lương tháng 13</li></ul>", new DateTimeOffset(new DateTime(2023, 4, 28, 8, 53, 4, 75, DateTimeKind.Unspecified).AddTicks(2032), new TimeSpan(0, 7, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "RecruimentNews",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Benefit", "CreatedAt" },
                values: new object[] { "<ul><li>Bảo hiểm xã hội full lương</li><li>Lương tháng 13</li></ul>", new DateTimeOffset(new DateTime(2023, 4, 28, 8, 53, 4, 75, DateTimeKind.Unspecified).AddTicks(2035), new TimeSpan(0, 7, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "RecruimentNews",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Benefit", "CreatedAt" },
                values: new object[] { "<ul><li>Bảo hiểm xã hội full lương</li><li>Lương tháng 13</li></ul>", new DateTimeOffset(new DateTime(2023, 4, 28, 8, 53, 4, 75, DateTimeKind.Unspecified).AddTicks(2035), new TimeSpan(0, 7, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "RecruimentNews",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Benefit", "CreatedAt" },
                values: new object[] { "<ul><li>Bảo hiểm xã hội full lương</li><li>Lương tháng 13</li></ul>", new DateTimeOffset(new DateTime(2023, 4, 28, 8, 53, 4, 75, DateTimeKind.Unspecified).AddTicks(2036), new TimeSpan(0, 7, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "RecruimentNews",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Benefit", "CreatedAt" },
                values: new object[] { "<ul><li>Bảo hiểm xã hội full lương</li><li>Lương tháng 13</li></ul>", new DateTimeOffset(new DateTime(2023, 4, 28, 8, 53, 4, 75, DateTimeKind.Unspecified).AddTicks(2037), new TimeSpan(0, 7, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "RecruimentNews",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Benefit", "CreatedAt" },
                values: new object[] { "<ul><li>Bảo hiểm xã hội full lương</li><li>Lương tháng 13</li></ul>", new DateTimeOffset(new DateTime(2023, 4, 28, 8, 53, 4, 75, DateTimeKind.Unspecified).AddTicks(2038), new TimeSpan(0, 7, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "RecruimentNews",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Benefit", "CreatedAt" },
                values: new object[] { "<ul><li>Bảo hiểm xã hội full lương</li><li>Lương tháng 13</li></ul>", new DateTimeOffset(new DateTime(2023, 4, 28, 8, 53, 4, 75, DateTimeKind.Unspecified).AddTicks(2038), new TimeSpan(0, 7, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "RecruimentNews",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Benefit", "CreatedAt" },
                values: new object[] { "<ul><li>Bảo hiểm xã hội full lương</li><li>Lương tháng 13</li></ul>", new DateTimeOffset(new DateTime(2023, 4, 28, 8, 53, 4, 75, DateTimeKind.Unspecified).AddTicks(2039), new TimeSpan(0, 7, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "RecruimentNews",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Benefit", "CreatedAt" },
                values: new object[] { "<ul><li>Bảo hiểm xã hội full lương</li><li>Lương tháng 13</li></ul>", new DateTimeOffset(new DateTime(2023, 4, 28, 8, 53, 4, 75, DateTimeKind.Unspecified).AddTicks(2040), new TimeSpan(0, 7, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 4, 28, 8, 53, 4, 75, DateTimeKind.Unspecified).AddTicks(793), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 4, 28, 8, 53, 4, 75, DateTimeKind.Unspecified).AddTicks(702), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 4, 28, 8, 53, 4, 75, DateTimeKind.Unspecified).AddTicks(174), new TimeSpan(0, 7, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Benefit",
                table: "RecruimentNews");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 4, 25, 14, 29, 4, 996, DateTimeKind.Unspecified).AddTicks(9842), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 4, 25, 14, 29, 4, 996, DateTimeKind.Unspecified).AddTicks(9852), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 4, 25, 14, 29, 4, 996, DateTimeKind.Unspecified).AddTicks(9854), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RecruimentNews",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 4, 25, 14, 29, 4, 996, DateTimeKind.Unspecified).AddTicks(7093), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RecruimentNews",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 4, 25, 14, 29, 4, 996, DateTimeKind.Unspecified).AddTicks(7101), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RecruimentNews",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 4, 25, 14, 29, 4, 996, DateTimeKind.Unspecified).AddTicks(7102), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RecruimentNews",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 4, 25, 14, 29, 4, 996, DateTimeKind.Unspecified).AddTicks(7103), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RecruimentNews",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 4, 25, 14, 29, 4, 996, DateTimeKind.Unspecified).AddTicks(7105), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RecruimentNews",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 4, 25, 14, 29, 4, 996, DateTimeKind.Unspecified).AddTicks(7106), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RecruimentNews",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 4, 25, 14, 29, 4, 996, DateTimeKind.Unspecified).AddTicks(7107), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RecruimentNews",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 4, 25, 14, 29, 4, 996, DateTimeKind.Unspecified).AddTicks(7109), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RecruimentNews",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 4, 25, 14, 29, 4, 996, DateTimeKind.Unspecified).AddTicks(7110), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 4, 25, 14, 29, 4, 996, DateTimeKind.Unspecified).AddTicks(4901), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 4, 25, 14, 29, 4, 996, DateTimeKind.Unspecified).AddTicks(4730), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 4, 25, 14, 29, 4, 996, DateTimeKind.Unspecified).AddTicks(3920), new TimeSpan(0, 7, 0, 0, 0)));
        }
    }
}
