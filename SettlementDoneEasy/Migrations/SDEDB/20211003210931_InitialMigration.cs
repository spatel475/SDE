using Microsoft.EntityFrameworkCore.Migrations;

namespace SDE_Server.Migrations.SDEDB
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DocumentTemplateData",
                columns: table => new
                {
                    TemplateID = table.Column<int>(type: "int", nullable: true),
                    Template = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "FlowTemplate",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Machine = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowTemplate", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Organization",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Type = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Email = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    OrganizationID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Users.OrganizationID",
                        column: x => x.OrganizationID,
                        principalTable: "Organization",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DocumentTemplate",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    OrganizationID = table.Column<int>(type: "int", nullable: true),
                    Creator = table.Column<int>(type: "int", nullable: true),
                    FlowTemplate = table.Column<int>(type: "int", nullable: true),
                    Data = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentTemplate", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DocumentTemplate_FlowTemplate",
                        column: x => x.FlowTemplate,
                        principalTable: "FlowTemplate",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DocumentTemplate_Users",
                        column: x => x.Creator,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DocumentTemplate.OrganizationID",
                        column: x => x.OrganizationID,
                        principalTable: "Organization",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    Data = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    TemplateID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Document_DocumentTemplate",
                        column: x => x.TemplateID,
                        principalTable: "DocumentTemplate",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Document.UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DocumentAudit",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    DocID = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    FlowState = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentAudit", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DocumentAudit_Document",
                        column: x => x.DocID,
                        principalTable: "Document",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DocumentData",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    AdjustedData = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ArchiveData = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentData", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DocumentData_Document",
                        column: x => x.ID,
                        principalTable: "Document",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DocumentUser",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    DocID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentUser", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DocumentUser_Document",
                        column: x => x.DocID,
                        principalTable: "Document",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DocumentUser.UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Document_TemplateID",
                table: "Document",
                column: "TemplateID");

            migrationBuilder.CreateIndex(
                name: "IX_Document_UserID",
                table: "Document",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentAudit_DocID",
                table: "DocumentAudit",
                column: "DocID");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentTemplate_Creator",
                table: "DocumentTemplate",
                column: "Creator");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentTemplate_FlowTemplate",
                table: "DocumentTemplate",
                column: "FlowTemplate");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentTemplate_OrganizationID",
                table: "DocumentTemplate",
                column: "OrganizationID");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentUser_DocID",
                table: "DocumentUser",
                column: "DocID");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentUser_UserID",
                table: "DocumentUser",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_User_OrganizationID",
                table: "User",
                column: "OrganizationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentAudit");

            migrationBuilder.DropTable(
                name: "DocumentData");

            migrationBuilder.DropTable(
                name: "DocumentTemplateData");

            migrationBuilder.DropTable(
                name: "DocumentUser");

            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DropTable(
                name: "DocumentTemplate");

            migrationBuilder.DropTable(
                name: "FlowTemplate");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Organization");
        }
    }
}
