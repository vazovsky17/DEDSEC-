using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DEDSEC.EntityFramework.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Donations");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "DonationGoals");

            migrationBuilder.AddColumn<Guid>(
                name: "AccountId",
                table: "Meetings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_AccountId",
                table: "Meetings",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meetings_Accounts_AccountId",
                table: "Meetings",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meetings_Accounts_AccountId",
                table: "Meetings");

            migrationBuilder.DropIndex(
                name: "IX_Meetings_AccountId",
                table: "Meetings");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Meetings");

            migrationBuilder.CreateTable(
                name: "DonationGoals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrentValue = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TargetValue = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonationGoals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReviewAuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Accounts_ReviewAuthorId",
                        column: x => x.ReviewAuthorId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Donations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DonaterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DonationGoalId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Donations_Accounts_DonaterId",
                        column: x => x.DonaterId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Donations_DonationGoals_DonationGoalId",
                        column: x => x.DonationGoalId,
                        principalTable: "DonationGoals",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Donations_DonaterId",
                table: "Donations",
                column: "DonaterId");

            migrationBuilder.CreateIndex(
                name: "IX_Donations_DonationGoalId",
                table: "Donations",
                column: "DonationGoalId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_GameId",
                table: "Reviews",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ReviewAuthorId",
                table: "Reviews",
                column: "ReviewAuthorId");
        }
    }
}
