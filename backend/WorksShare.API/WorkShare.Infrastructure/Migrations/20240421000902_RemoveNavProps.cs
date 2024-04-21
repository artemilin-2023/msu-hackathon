using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkShare.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveNavProps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Works_Users_UserEntityId",
                table: "Works");

            migrationBuilder.DropIndex(
                name: "IX_Works_UserEntityId",
                table: "Works");

            migrationBuilder.RenameColumn(
                name: "UserEntityId",
                table: "Works",
                newName: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Works",
                newName: "UserEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Works_UserEntityId",
                table: "Works",
                column: "UserEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Works_Users_UserEntityId",
                table: "Works",
                column: "UserEntityId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
