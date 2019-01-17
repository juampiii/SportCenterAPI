using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportCenterAPI.Migrations
{
    public partial class SeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Courts_CourtForeignKey",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_User_MemberForeignKey",
                table: "Booking");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Booking",
                table: "Booking");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Booking_CourtForeignKey_MemberForeignKey_BookingDate",
                table: "Booking");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Booking",
                newName: "Bookings");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_MemberForeignKey",
                table: "Bookings",
                newName: "IX_Bookings_MemberForeignKey");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings",
                column: "Id");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Bookings_CourtForeignKey_MemberForeignKey_BookingDate",
                table: "Bookings",
                columns: new[] { "CourtForeignKey", "MemberForeignKey", "BookingDate" });

            migrationBuilder.InsertData(
                table: "Sports",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Padel" },
                    { 2, "Futbol" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Discriminator", "Name", "Password" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Administrator", "Admin", "12341234" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Discriminator", "Name", "Password", "Phone" },
                values: new object[,]
                {
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Member", "Member1", "12341234", null },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Member", "Member2", "12341234", null }
                });

            migrationBuilder.InsertData(
                table: "Courts",
                columns: new[] { "Id", "Name", "SportForeignKey" },
                values: new object[,]
                {
                    { 1, "Padel Court 1", 1 },
                    { 2, "Padel Court 2", 1 },
                    { 3, "Futbol Court 1", 2 },
                    { 4, "Futbol Court 2", 2 }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "BookingDate", "CourtForeignKey", "CreatedDate", "MemberForeignKey" },
                values: new object[] { 1, new DateTime(2019, 1, 17, 14, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2019, 1, 17, 11, 22, 25, 561, DateTimeKind.Local).AddTicks(583), 2 });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "BookingDate", "CourtForeignKey", "CreatedDate", "MemberForeignKey" },
                values: new object[] { 2, new DateTime(2019, 1, 17, 21, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2019, 1, 17, 11, 22, 25, 562, DateTimeKind.Local).AddTicks(8592), 3 });

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Courts_CourtForeignKey",
                table: "Bookings",
                column: "CourtForeignKey",
                principalTable: "Courts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Users_MemberForeignKey",
                table: "Bookings",
                column: "MemberForeignKey",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Courts_CourtForeignKey",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Users_MemberForeignKey",
                table: "Bookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Bookings_CourtForeignKey_MemberForeignKey_BookingDate",
                table: "Bookings");

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Bookings",
                newName: "Booking");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_MemberForeignKey",
                table: "Booking",
                newName: "IX_Booking_MemberForeignKey");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "User",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Booking",
                table: "Booking",
                column: "Id");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Booking_CourtForeignKey_MemberForeignKey_BookingDate",
                table: "Booking",
                columns: new[] { "CourtForeignKey", "MemberForeignKey", "BookingDate" });

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Courts_CourtForeignKey",
                table: "Booking",
                column: "CourtForeignKey",
                principalTable: "Courts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_User_MemberForeignKey",
                table: "Booking",
                column: "MemberForeignKey",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
