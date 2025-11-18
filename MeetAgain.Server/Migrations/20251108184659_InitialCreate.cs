using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MeetAgain.Server.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Availabilities",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MeetupId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FriendId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProposedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Availabilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FriendGroups",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberIds = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Friends",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupIds = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friends", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Meetups",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    ProposedDates = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SelectedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ParticipantIds = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GroupId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotificationSent = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meetups", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "FriendGroups",
                columns: new[] { "Id", "Color", "CreatedAt", "Description", "MemberIds", "Name" },
                values: new object[,]
                {
                    { "g1", "#6366f1", new DateTime(2025, 11, 8, 18, 46, 59, 11, DateTimeKind.Utc).AddTicks(6067), "Office colleagues", "", "Work Team" },
                    { "g2", "#10b981", new DateTime(2025, 11, 8, 18, 46, 59, 11, DateTimeKind.Utc).AddTicks(6288), "University buddies", "", "College Friends" }
                });

            migrationBuilder.InsertData(
                table: "Friends",
                columns: new[] { "Id", "Avatar", "CreatedAt", "Email", "GroupIds", "Name", "Phone" },
                values: new object[,]
                {
                    { "1", "AJ", new DateTime(2025, 11, 8, 18, 46, 59, 10, DateTimeKind.Utc).AddTicks(7985), "alice@example.com", "", "Alice Johnson", "" },
                    { "2", "BS", new DateTime(2025, 11, 8, 18, 46, 59, 10, DateTimeKind.Utc).AddTicks(8396), "bob@example.com", "", "Bob Smith", "" },
                    { "3", "CW", new DateTime(2025, 11, 8, 18, 46, 59, 10, DateTimeKind.Utc).AddTicks(8403), "carol@example.com", "", "Carol White", "" },
                    { "4", "DB", new DateTime(2025, 11, 8, 18, 46, 59, 10, DateTimeKind.Utc).AddTicks(8406), "david@example.com", "", "David Brown", "" },
                    { "5", "ED", new DateTime(2025, 11, 8, 18, 46, 59, 10, DateTimeKind.Utc).AddTicks(8410), "emma@example.com", "", "Emma Davis", "" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Availabilities_FriendId",
                table: "Availabilities",
                column: "FriendId");

            migrationBuilder.CreateIndex(
                name: "IX_Availabilities_MeetupId",
                table: "Availabilities",
                column: "MeetupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Availabilities");

            migrationBuilder.DropTable(
                name: "FriendGroups");

            migrationBuilder.DropTable(
                name: "Friends");

            migrationBuilder.DropTable(
                name: "Meetups");
        }
    }
}
