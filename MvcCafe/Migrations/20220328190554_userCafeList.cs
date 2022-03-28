using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcCafe.Migrations
{
    public partial class userCafeList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Cafe",
                table: "Cafe");

            migrationBuilder.RenameTable(
                name: "Cafe",
                newName: "Cafes");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Cafes",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cafes",
                table: "Cafes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cafes_UserId",
                table: "Cafes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cafes_Users_UserId",
                table: "Cafes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cafes_Users_UserId",
                table: "Cafes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cafes",
                table: "Cafes");

            migrationBuilder.DropIndex(
                name: "IX_Cafes_UserId",
                table: "Cafes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Cafes");

            migrationBuilder.RenameTable(
                name: "Cafes",
                newName: "Cafe");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cafe",
                table: "Cafe",
                column: "Id");
        }
    }
}
