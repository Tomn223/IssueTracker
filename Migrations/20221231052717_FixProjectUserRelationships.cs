using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IssueTracker.Migrations
{
    /// <inheritdoc />
    public partial class FixProjectUserRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Manager_ManagerId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_Member_MemberId",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_ManagerId",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_MemberId",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "Project");

            migrationBuilder.CreateTable(
                name: "ManagerProject",
                columns: table => new
                {
                    ManagersId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProjectsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagerProject", x => new { x.ManagersId, x.ProjectsId });
                    table.ForeignKey(
                        name: "FK_ManagerProject_Manager_ManagersId",
                        column: x => x.ManagersId,
                        principalTable: "Manager",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ManagerProject_Project_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MemberProject",
                columns: table => new
                {
                    MembersId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProjectsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberProject", x => new { x.MembersId, x.ProjectsId });
                    table.ForeignKey(
                        name: "FK_MemberProject_Member_MembersId",
                        column: x => x.MembersId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MemberProject_Project_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ManagerProject_ProjectsId",
                table: "ManagerProject",
                column: "ProjectsId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberProject_ProjectsId",
                table: "MemberProject",
                column: "ProjectsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ManagerProject");

            migrationBuilder.DropTable(
                name: "MemberProject");

            migrationBuilder.AddColumn<int>(
                name: "ManagerId",
                table: "Project",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MemberId",
                table: "Project",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Project_ManagerId",
                table: "Project",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_MemberId",
                table: "Project",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Manager_ManagerId",
                table: "Project",
                column: "ManagerId",
                principalTable: "Manager",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Member_MemberId",
                table: "Project",
                column: "MemberId",
                principalTable: "Member",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
