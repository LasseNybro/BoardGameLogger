using Microsoft.EntityFrameworkCore.Migrations;

namespace BoardGameLogger.Data.Migrations
{
    public partial class sessionlist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_BoardGames_BoardGamePlayedId",
                table: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_Sessions_BoardGamePlayedId",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "BoardGamePlayedId",
                table: "Sessions");

            migrationBuilder.AddColumn<int>(
                name: "BoardGameId",
                table: "Sessions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "BoardGames",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "BoardGames",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_BoardGameId",
                table: "Sessions",
                column: "BoardGameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_BoardGames_BoardGameId",
                table: "Sessions",
                column: "BoardGameId",
                principalTable: "BoardGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_BoardGames_BoardGameId",
                table: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_Sessions_BoardGameId",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "BoardGameId",
                table: "Sessions");

            migrationBuilder.AddColumn<int>(
                name: "BoardGamePlayedId",
                table: "Sessions",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "BoardGames",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "BoardGames",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_BoardGamePlayedId",
                table: "Sessions",
                column: "BoardGamePlayedId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_BoardGames_BoardGamePlayedId",
                table: "Sessions",
                column: "BoardGamePlayedId",
                principalTable: "BoardGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
