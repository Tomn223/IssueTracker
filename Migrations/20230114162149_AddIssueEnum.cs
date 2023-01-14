using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IssueTracker.Migrations
{
    /// <inheritdoc />
    public partial class AddIssueEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issue_Project_ProjectId",
                table: "Issue");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "Issue",
                newName: "ProjectID");

            migrationBuilder.RenameIndex(
                name: "IX_Issue_ProjectId",
                table: "Issue",
                newName: "IX_Issue_ProjectID");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Issue",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_Issue_Project_ProjectID",
                table: "Issue",
                column: "ProjectID",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issue_Project_ProjectID",
                table: "Issue");

            migrationBuilder.RenameColumn(
                name: "ProjectID",
                table: "Issue",
                newName: "ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Issue_ProjectID",
                table: "Issue",
                newName: "IX_Issue_ProjectId");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Issue",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Issue_Project_ProjectId",
                table: "Issue",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
