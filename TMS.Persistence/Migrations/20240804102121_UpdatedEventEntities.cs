using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedEventEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "TMSEvents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TMSEvents_AppUserId",
                table: "TMSEvents",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TMSEvents_AppUsers_AppUserId",
                table: "TMSEvents",
                column: "AppUserId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TMSEvents_AppUsers_AppUserId",
                table: "TMSEvents");

            migrationBuilder.DropIndex(
                name: "IX_TMSEvents_AppUserId",
                table: "TMSEvents");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "TMSEvents");
        }
    }
}
