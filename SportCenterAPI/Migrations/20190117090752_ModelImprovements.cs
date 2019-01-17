using Microsoft.EntityFrameworkCore.Migrations;

namespace SportCenterAPI.Migrations
{
    public partial class ModelImprovements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Courts_CourtId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_User_MemberId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Courts_Sports_SportId",
                table: "Courts");

            migrationBuilder.DropIndex(
                name: "IX_Courts_SportId",
                table: "Courts");

            migrationBuilder.DropIndex(
                name: "IX_Booking_CourtId",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_MemberId",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "SportId",
                table: "Courts");

            migrationBuilder.DropColumn(
                name: "CourtId",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "Booking");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SportId",
                table: "Courts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CourtId",
                table: "Booking",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MemberId",
                table: "Booking",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courts_SportId",
                table: "Courts",
                column: "SportId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_CourtId",
                table: "Booking",
                column: "CourtId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_MemberId",
                table: "Booking",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Courts_CourtId",
                table: "Booking",
                column: "CourtId",
                principalTable: "Courts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_User_MemberId",
                table: "Booking",
                column: "MemberId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Courts_Sports_SportId",
                table: "Courts",
                column: "SportId",
                principalTable: "Sports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
