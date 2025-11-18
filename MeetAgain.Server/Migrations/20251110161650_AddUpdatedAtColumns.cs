using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeetAgain.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddUpdatedAtColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Meetups",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Friends",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "FriendGroups",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Availabilities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "FriendGroups",
                keyColumn: "Id",
                keyValue: "g1",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 10, 16, 16, 50, 119, DateTimeKind.Utc).AddTicks(3125), new DateTime(2025, 11, 10, 16, 16, 50, 119, DateTimeKind.Utc).AddTicks(2418) });

            migrationBuilder.UpdateData(
                table: "FriendGroups",
                keyColumn: "Id",
                keyValue: "g2",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 10, 16, 16, 50, 119, DateTimeKind.Utc).AddTicks(3281), new DateTime(2025, 11, 10, 16, 16, 50, 119, DateTimeKind.Utc).AddTicks(3280) });

            migrationBuilder.UpdateData(
                table: "Friends",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 10, 16, 16, 50, 118, DateTimeKind.Utc).AddTicks(7760), new DateTime(2025, 11, 10, 16, 16, 50, 118, DateTimeKind.Utc).AddTicks(7044) });

            migrationBuilder.UpdateData(
                table: "Friends",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 10, 16, 16, 50, 118, DateTimeKind.Utc).AddTicks(7943), new DateTime(2025, 11, 10, 16, 16, 50, 118, DateTimeKind.Utc).AddTicks(7942) });

            migrationBuilder.UpdateData(
                table: "Friends",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 10, 16, 16, 50, 118, DateTimeKind.Utc).AddTicks(7956), new DateTime(2025, 11, 10, 16, 16, 50, 118, DateTimeKind.Utc).AddTicks(7956) });

            migrationBuilder.UpdateData(
                table: "Friends",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 10, 16, 16, 50, 118, DateTimeKind.Utc).AddTicks(7959), new DateTime(2025, 11, 10, 16, 16, 50, 118, DateTimeKind.Utc).AddTicks(7959) });

            migrationBuilder.UpdateData(
                table: "Friends",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 10, 16, 16, 50, 118, DateTimeKind.Utc).AddTicks(7962), new DateTime(2025, 11, 10, 16, 16, 50, 118, DateTimeKind.Utc).AddTicks(7962) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Meetups");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Friends");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "FriendGroups");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Availabilities");

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
    }
}
