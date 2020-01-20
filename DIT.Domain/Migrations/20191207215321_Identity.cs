using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DIT.Domain.Migrations
{
    public partial class Identity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Connectors_Users_UserId1",
                schema: "dit",
                table: "Connectors");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Users_UserId",
                schema: "dit",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Organizations_OrganizationId",
                schema: "dit",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Projects_UserId",
                schema: "dit",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Connectors_UserId1",
                schema: "dit",
                table: "Connectors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                schema: "dit",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserId1",
                schema: "dit",
                table: "Connectors");

            migrationBuilder.RenameTable(
                name: "Users",
                schema: "dit",
                newName: "AspNetUsers",
                newSchema: "dit");

            migrationBuilder.RenameIndex(
                name: "IX_Users_OrganizationId",
                schema: "dit",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_OrganizationId");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                schema: "dit",
                table: "Projects",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "dit",
                table: "Connectors",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "dit",
                table: "AspNetUsers",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "dit",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                schema: "dit",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                schema: "dit",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                schema: "dit",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                schema: "dit",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                schema: "dit",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                schema: "dit",
                table: "AspNetUsers",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                schema: "dit",
                table: "AspNetUsers",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                schema: "dit",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                schema: "dit",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                schema: "dit",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                schema: "dit",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                schema: "dit",
                table: "AspNetUsers",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUsers",
                schema: "dit",
                table: "AspNetUsers",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                schema: "dit",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                schema: "dit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dit",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                schema: "dit",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dit",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                schema: "dit",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dit",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                schema: "dit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dit",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                schema: "dit",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dit",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dit",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_UserId1",
                schema: "dit",
                table: "Projects",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Connectors_UserId",
                schema: "dit",
                table: "Connectors",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "dit",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "dit",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                schema: "dit",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "dit",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                schema: "dit",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                schema: "dit",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "dit",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Organizations_OrganizationId",
                schema: "dit",
                table: "AspNetUsers",
                column: "OrganizationId",
                principalSchema: "dit",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Connectors_AspNetUsers_UserId",
                schema: "dit",
                table: "Connectors",
                column: "UserId",
                principalSchema: "dit",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_AspNetUsers_UserId1",
                schema: "dit",
                table: "Projects",
                column: "UserId1",
                principalSchema: "dit",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Organizations_OrganizationId",
                schema: "dit",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Connectors_AspNetUsers_UserId",
                schema: "dit",
                table: "Connectors");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_AspNetUsers_UserId1",
                schema: "dit",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims",
                schema: "dit");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims",
                schema: "dit");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins",
                schema: "dit");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles",
                schema: "dit");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens",
                schema: "dit");

            migrationBuilder.DropTable(
                name: "AspNetRoles",
                schema: "dit");

            migrationBuilder.DropIndex(
                name: "IX_Projects_UserId1",
                schema: "dit",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Connectors_UserId",
                schema: "dit",
                table: "Connectors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsers",
                schema: "dit",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "EmailIndex",
                schema: "dit",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                schema: "dit",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserId1",
                schema: "dit",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                schema: "dit",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                schema: "dit",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                schema: "dit",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                schema: "dit",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                schema: "dit",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                schema: "dit",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                schema: "dit",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                schema: "dit",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                schema: "dit",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                schema: "dit",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                schema: "dit",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserName",
                schema: "dit",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                schema: "dit",
                newName: "Users",
                newSchema: "dit");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_OrganizationId",
                schema: "dit",
                table: "Users",
                newName: "IX_Users_OrganizationId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "dit",
                table: "Connectors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId1",
                schema: "dit",
                table: "Connectors",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "dit",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                schema: "dit",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                schema: "dit",
                table: "Users",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_UserId",
                schema: "dit",
                table: "Projects",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Connectors_UserId1",
                schema: "dit",
                table: "Connectors",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Connectors_Users_UserId1",
                schema: "dit",
                table: "Connectors",
                column: "UserId1",
                principalSchema: "dit",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Users_UserId",
                schema: "dit",
                table: "Projects",
                column: "UserId",
                principalSchema: "dit",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Organizations_OrganizationId",
                schema: "dit",
                table: "Users",
                column: "OrganizationId",
                principalSchema: "dit",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
