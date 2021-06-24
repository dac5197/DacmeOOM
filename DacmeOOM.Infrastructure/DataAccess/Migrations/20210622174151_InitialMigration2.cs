using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DacmeOOM.Infrastructure.EFCore.DataAccess.Migrations
{
    public partial class InitialMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrgTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrgTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrgLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    OrgTypeId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrgLevels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrgLevels_OrgTypes_OrgTypeId",
                        column: x => x.OrgTypeId,
                        principalTable: "OrgTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrgUnits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OrgModelId = table.Column<int>(type: "int", nullable: false),
                    OrgId = table.Column<int>(type: "int", nullable: true),
                    Path = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrgUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrgUnits_OrgLevels_OrgId",
                        column: x => x.OrgId,
                        principalTable: "OrgLevels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    OrgUnitId = table.Column<int>(type: "int", nullable: false),
                    OrgModelId = table.Column<int>(type: "int", nullable: false),
                    OrgId = table.Column<int>(type: "int", nullable: true),
                    Path = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeRoles_OrgLevels_OrgId",
                        column: x => x.OrgId,
                        principalTable: "OrgLevels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeRoles_OrgUnits_OrgUnitId",
                        column: x => x.OrgUnitId,
                        principalTable: "OrgUnits",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TermDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_EmployeeRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "EmployeeRoles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRoles_OrgId",
                table: "EmployeeRoles",
                column: "OrgId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRoles_OrgUnitId",
                table: "EmployeeRoles",
                column: "OrgUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_RoleId",
                table: "Employees",
                column: "RoleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrgLevels_OrgTypeId",
                table: "OrgLevels",
                column: "OrgTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrgUnits_OrgId",
                table: "OrgUnits",
                column: "OrgId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "EmployeeRoles");

            migrationBuilder.DropTable(
                name: "OrgUnits");

            migrationBuilder.DropTable(
                name: "OrgLevels");

            migrationBuilder.DropTable(
                name: "OrgTypes");
        }
    }
}
