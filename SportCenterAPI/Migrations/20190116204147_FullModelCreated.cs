using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportCenterAPI.Migrations
{
    public partial class FullModelCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courts_Sports_SportForeignKey",
                table: "Courts");

            migrationBuilder.AlterColumn<int>(
                name: "SportForeignKey",
                table: "Courts",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SportId",
                table: "Courts",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Password = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MemberForeignKey = table.Column<int>(nullable: false),
                    CourtForeignKey = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    BookingDate = table.Column<DateTime>(nullable: false),
                    MemberId = table.Column<int>(nullable: true),
                    CourtId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.Id);
                    table.UniqueConstraint("AK_Booking_CourtForeignKey_MemberForeignKey_BookingDate", x => new { x.CourtForeignKey, x.MemberForeignKey, x.BookingDate });
                    table.ForeignKey(
                        name: "FK_Booking_Courts_CourtForeignKey",
                        column: x => x.CourtForeignKey,
                        principalTable: "Courts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Booking_Courts_CourtId",
                        column: x => x.CourtId,
                        principalTable: "Courts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Booking_User_MemberForeignKey",
                        column: x => x.MemberForeignKey,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Booking_User_MemberId",
                        column: x => x.MemberId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courts_SportId",
                table: "Courts",
                column: "SportId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_CourtId",
                table: "Booking",
                column: "CourtId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_MemberForeignKey",
                table: "Booking",
                column: "MemberForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_MemberId",
                table: "Booking",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courts_Sports_SportForeignKey",
                table: "Courts",
                column: "SportForeignKey",
                principalTable: "Sports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Courts_Sports_SportId",
                table: "Courts",
                column: "SportId",
                principalTable: "Sports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courts_Sports_SportForeignKey",
                table: "Courts");

            migrationBuilder.DropForeignKey(
                name: "FK_Courts_Sports_SportId",
                table: "Courts");

            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_Courts_SportId",
                table: "Courts");

            migrationBuilder.DropColumn(
                name: "SportId",
                table: "Courts");

            migrationBuilder.AlterColumn<int>(
                name: "SportForeignKey",
                table: "Courts",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Courts_Sports_SportForeignKey",
                table: "Courts",
                column: "SportForeignKey",
                principalTable: "Sports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
