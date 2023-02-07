using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Manipulaê.Infraestruture.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Kind = table.Column<string>(type: "TEXT", nullable: true),
                    Etag = table.Column<string>(type: "TEXT", nullable: true),
                    VideoId = table.Column<string>(type: "TEXT", nullable: true),
                    KindId = table.Column<string>(type: "TEXT", nullable: true),
                    IsEnable = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
