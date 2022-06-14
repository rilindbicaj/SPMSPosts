using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class InitialSomee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AudienceGroups",
                columns: table => new
                {
                    AudienceGroupID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AudienceGroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FacultyFilter = table.Column<int>(type: "int", nullable: false),
                    GenerationFilter = table.Column<int>(type: "int", nullable: false),
                    RoleFilter = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AudienceGroups", x => x.AudienceGroupID);
                });

            migrationBuilder.CreateTable(
                name: "EmailSubscriptions",
                columns: table => new
                {
                    User = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailSubscriptions", x => x.User);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Contents = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Audience = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostID);
                    table.ForeignKey(
                        name: "FK_Posts_AudienceGroups_Audience",
                        column: x => x.Audience,
                        principalTable: "AudienceGroups",
                        principalColumn: "AudienceGroupID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_Audience",
                table: "Posts",
                column: "Audience");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailSubscriptions");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "AudienceGroups");
        }
    }
}
