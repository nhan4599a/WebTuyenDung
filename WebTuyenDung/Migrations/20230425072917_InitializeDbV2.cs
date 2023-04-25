using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebTuyenDung.Migrations
{
    /// <inheritdoc />
    public partial class InitializeDbV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CurriculumVitaeDetail_CVs_CVId",
                table: "CurriculumVitaeDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CurriculumVitaeDetail",
                table: "CurriculumVitaeDetail");

            migrationBuilder.RenameTable(
                name: "CurriculumVitaeDetail",
                newName: "CVDetails");

            migrationBuilder.RenameIndex(
                name: "IX_CurriculumVitaeDetail_CVId",
                table: "CVDetails",
                newName: "IX_CVDetails_CVId");

            migrationBuilder.AlterColumn<string>(
                name: "Rewards",
                table: "CVDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CVDetails",
                table: "CVDetails",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_CVDetails_CVs_CVId",
                table: "CVDetails",
                column: "CVId",
                principalTable: "CVs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CVDetails_CVs_CVId",
                table: "CVDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CVDetails",
                table: "CVDetails");

            migrationBuilder.RenameTable(
                name: "CVDetails",
                newName: "CurriculumVitaeDetail");

            migrationBuilder.RenameIndex(
                name: "IX_CVDetails_CVId",
                table: "CurriculumVitaeDetail",
                newName: "IX_CurriculumVitaeDetail_CVId");

            migrationBuilder.AlterColumn<string>(
                name: "Rewards",
                table: "CurriculumVitaeDetail",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CurriculumVitaeDetail",
                table: "CurriculumVitaeDetail",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 4, 24, 16, 19, 11, 859, DateTimeKind.Unspecified).AddTicks(8191), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 4, 24, 16, 19, 11, 859, DateTimeKind.Unspecified).AddTicks(8206), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 4, 24, 16, 19, 11, 859, DateTimeKind.Unspecified).AddTicks(8207), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RecruimentNews",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 4, 24, 16, 19, 11, 859, DateTimeKind.Unspecified).AddTicks(4882), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RecruimentNews",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 4, 24, 16, 19, 11, 859, DateTimeKind.Unspecified).AddTicks(4892), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RecruimentNews",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 4, 24, 16, 19, 11, 859, DateTimeKind.Unspecified).AddTicks(4898), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RecruimentNews",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 4, 24, 16, 19, 11, 859, DateTimeKind.Unspecified).AddTicks(4900), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RecruimentNews",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 4, 24, 16, 19, 11, 859, DateTimeKind.Unspecified).AddTicks(4901), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RecruimentNews",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 4, 24, 16, 19, 11, 859, DateTimeKind.Unspecified).AddTicks(4902), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RecruimentNews",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 4, 24, 16, 19, 11, 859, DateTimeKind.Unspecified).AddTicks(4905), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RecruimentNews",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 4, 24, 16, 19, 11, 859, DateTimeKind.Unspecified).AddTicks(4907), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "RecruimentNews",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 4, 24, 16, 19, 11, 859, DateTimeKind.Unspecified).AddTicks(4908), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 4, 24, 16, 19, 11, 859, DateTimeKind.Unspecified).AddTicks(2207), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 4, 24, 16, 19, 11, 859, DateTimeKind.Unspecified).AddTicks(1803), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2023, 4, 24, 16, 19, 11, 859, DateTimeKind.Unspecified).AddTicks(458), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.AddForeignKey(
                name: "FK_CurriculumVitaeDetail_CVs_CVId",
                table: "CurriculumVitaeDetail",
                column: "CVId",
                principalTable: "CVs",
                principalColumn: "Id");
        }
    }
}
