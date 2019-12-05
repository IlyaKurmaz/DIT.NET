using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DIT.Domain.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dit");

            migrationBuilder.CreateTable(
                name: "FlowContents",
                schema: "dit",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowContents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                schema: "dit",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProcessContents",
                schema: "dit",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessContents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "dit",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    OrganizationId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalSchema: "dit",
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Connectors",
                schema: "dit",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    IsValid = table.Column<bool>(nullable: false),
                    UserId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Connectors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Connectors_Users_UserId1",
                        column: x => x.UserId1,
                        principalSchema: "dit",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                schema: "dit",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dit",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Processes",
                schema: "dit",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ProcessContentId = table.Column<Guid>(nullable: true),
                    ProjectId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Processes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Processes_ProcessContents_ProcessContentId",
                        column: x => x.ProcessContentId,
                        principalSchema: "dit",
                        principalTable: "ProcessContents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Processes_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalSchema: "dit",
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectConnectors",
                schema: "dit",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ConnectorId = table.Column<Guid>(nullable: true),
                    ProjectId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectConnectors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectConnectors_Connectors_ConnectorId",
                        column: x => x.ConnectorId,
                        principalSchema: "dit",
                        principalTable: "Connectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectConnectors_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalSchema: "dit",
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Flows",
                schema: "dit",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    FlowContentId = table.Column<Guid>(nullable: true),
                    ProcessId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flows_FlowContents_FlowContentId",
                        column: x => x.FlowContentId,
                        principalSchema: "dit",
                        principalTable: "FlowContents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flows_Processes_ProcessId",
                        column: x => x.ProcessId,
                        principalSchema: "dit",
                        principalTable: "Processes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Connectors_UserId1",
                schema: "dit",
                table: "Connectors",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Flows_FlowContentId",
                schema: "dit",
                table: "Flows",
                column: "FlowContentId");

            migrationBuilder.CreateIndex(
                name: "IX_Flows_ProcessId",
                schema: "dit",
                table: "Flows",
                column: "ProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_Processes_ProcessContentId",
                schema: "dit",
                table: "Processes",
                column: "ProcessContentId");

            migrationBuilder.CreateIndex(
                name: "IX_Processes_ProjectId",
                schema: "dit",
                table: "Processes",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectConnectors_ConnectorId",
                schema: "dit",
                table: "ProjectConnectors",
                column: "ConnectorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectConnectors_ProjectId",
                schema: "dit",
                table: "ProjectConnectors",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_UserId",
                schema: "dit",
                table: "Projects",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_OrganizationId",
                schema: "dit",
                table: "Users",
                column: "OrganizationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flows",
                schema: "dit");

            migrationBuilder.DropTable(
                name: "ProjectConnectors",
                schema: "dit");

            migrationBuilder.DropTable(
                name: "FlowContents",
                schema: "dit");

            migrationBuilder.DropTable(
                name: "Processes",
                schema: "dit");

            migrationBuilder.DropTable(
                name: "Connectors",
                schema: "dit");

            migrationBuilder.DropTable(
                name: "ProcessContents",
                schema: "dit");

            migrationBuilder.DropTable(
                name: "Projects",
                schema: "dit");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "dit");

            migrationBuilder.DropTable(
                name: "Organizations",
                schema: "dit");
        }
    }
}
