using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketAPI.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Places",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    CityId = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Places", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Places_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SiteEvents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: true),
                    PlaceId = table.Column<int>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false),
                    ShortDetails = table.Column<string>(nullable: true),
                    TicketPrice = table.Column<double>(nullable: false),
                    TicketsAmount = table.Column<int>(nullable: false),
                    LongDetails = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SiteEvents_Places_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Places",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SiteEventId = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Owner = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    IsConfirmed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_SiteEvents_SiteEventId",
                        column: x => x.SiteEventId,
                        principalTable: "SiteEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Places_CityId",
                table: "Places",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_SiteEvents_PlaceId",
                table: "SiteEvents",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_SiteEventId",
                table: "Tickets",
                column: "SiteEventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "SiteEvents");

            migrationBuilder.DropTable(
                name: "Places");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
