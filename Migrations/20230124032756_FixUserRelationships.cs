using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IssueTracker.Migrations
{
    /// <inheritdoc />
    public partial class FixUserRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ManagerProject");

            migrationBuilder.DropTable(
                name: "MemberProject");

            migrationBuilder.AddColumn<int>(
                name: "ManagerId",
                table: "Project",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MemberId",
                table: "Project",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IssueTrackerUserId",
                table: "Issue",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IssueTrackerUserId",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "IssueTrackerUserProject",
                columns: table => new
                {
                    ProjectsId = table.Column<int>(type: "INTEGER", nullable: false),
                    TeamId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueTrackerUserProject", x => new { x.ProjectsId, x.TeamId });
                    table.ForeignKey(
                        name: "FK_IssueTrackerUserProject_AspNetUsers_TeamId",
                        column: x => x.TeamId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IssueTrackerUserProject_Project_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Project_ManagerId",
                table: "Project",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_MemberId",
                table: "Project",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Issue_IssueTrackerUserId",
                table: "Issue",
                column: "IssueTrackerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_IssueTrackerUserId",
                table: "AspNetUsers",
                column: "IssueTrackerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueTrackerUserProject_TeamId",
                table: "IssueTrackerUserProject",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_IssueTrackerUserId",
                table: "AspNetUsers",
                column: "IssueTrackerUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Issue_AspNetUsers_IssueTrackerUserId",
                table: "Issue",
                column: "IssueTrackerUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Manager_ManagerId",
                table: "Project",
                column: "ManagerId",
                principalTable: "Manager",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Member_MemberId",
                table: "Project",
                column: "MemberId",
                principalTable: "Member",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_IssueTrackerUserId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Issue_AspNetUsers_IssueTrackerUserId",
                table: "Issue");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_Manager_ManagerId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_Member_MemberId",
                table: "Project");

            migrationBuilder.DropTable(
                name: "IssueTrackerUserProject");

            migrationBuilder.DropIndex(
                name: "IX_Project_ManagerId",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_MemberId",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Issue_IssueTrackerUserId",
                table: "Issue");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_IssueTrackerUserId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "IssueTrackerUserId",
                table: "Issue");

            migrationBuilder.DropColumn(
                name: "IssueTrackerUserId",
                table: "AspNetUsers");

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
    }
}
