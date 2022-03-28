using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcCafe.Migrations
{
    public partial class userIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Cafe");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "Cafe",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
