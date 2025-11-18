using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeetAgain.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddValueComparers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FriendGroups",
                keyColumn: "Id",
                keyValue: "g1",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 8, 18, 51, 14, 216, DateTimeKind.Utc).AddTicks(3556));

            migrationBuilder.UpdateData(
                table: "FriendGroups",
                keyColumn: "Id",
                keyValue: "g2",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 8, 18, 51, 14, 216, DateTimeKind.Utc).AddTicks(3712));

            migrationBuilder.UpdateData(
                table: "Friends",
                keyColumn: "Id",
                keyValue: "1",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 8, 18, 51, 14, 215, DateTimeKind.Utc).AddTicks(8012));

            migrationBuilder.UpdateData(
                table: "Friends",
                keyColumn: "Id",
                keyValue: "2",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 8, 18, 51, 14, 215, DateTimeKind.Utc).AddTicks(8219));

            migrationBuilder.UpdateData(
                table: "Friends",
                keyColumn: "Id",
                keyValue: "3",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 8, 18, 51, 14, 215, DateTimeKind.Utc).AddTicks(8223));

            migrationBuilder.UpdateData(
                table: "Friends",
                keyColumn: "Id",
                keyValue: "4",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 8, 18, 51, 14, 215, DateTimeKind.Utc).AddTicks(8234));

            migrationBuilder.UpdateData(
                table: "Friends",
                keyColumn: "Id",
                keyValue: "5",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 8, 18, 51, 14, 215, DateTimeKind.Utc).AddTicks(8237));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FriendGroups",
                keyColumn: "Id",
                keyValue: "g1",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 8, 18, 46, 59, 11, DateTimeKind.Utc).AddTicks(6067));

            migrationBuilder.UpdateData(
                table: "FriendGroups",
                keyColumn: "Id",
                keyValue: "g2",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 8, 18, 46, 59, 11, DateTimeKind.Utc).AddTicks(6288));

            migrationBuilder.UpdateData(
                table: "Friends",
                keyColumn: "Id",
                keyValue: "1",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 8, 18, 46, 59, 10, DateTimeKind.Utc).AddTicks(7985));

            migrationBuilder.UpdateData(
                table: "Friends",
                keyColumn: "Id",
                keyValue: "2",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 8, 18, 46, 59, 10, DateTimeKind.Utc).AddTicks(8396));

            migrationBuilder.UpdateData(
                table: "Friends",
                keyColumn: "Id",
                keyValue: "3",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 8, 18, 46, 59, 10, DateTimeKind.Utc).AddTicks(8403));

            migrationBuilder.UpdateData(
                table: "Friends",
                keyColumn: "Id",
                keyValue: "4",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 8, 18, 46, 59, 10, DateTimeKind.Utc).AddTicks(8406));

            migrationBuilder.UpdateData(
                table: "Friends",
                keyColumn: "Id",
                keyValue: "5",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 8, 18, 46, 59, 10, DateTimeKind.Utc).AddTicks(8410));
        }
    }
}
