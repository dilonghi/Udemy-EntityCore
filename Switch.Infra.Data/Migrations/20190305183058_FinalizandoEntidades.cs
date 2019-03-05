using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Switch.Infra.Data.Migrations
{
    public partial class FinalizandoEntidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Identification_Users_UserId",
                table: "Identification");

            migrationBuilder.DropForeignKey(
                name: "FK_RelationshipStatus_Users_UserId",
                table: "RelationshipStatus");

            migrationBuilder.DropIndex(
                name: "IX_RelationshipStatus_UserId",
                table: "RelationshipStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Identification",
                table: "Identification");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "RelationshipStatus");

            migrationBuilder.RenameTable(
                name: "Identification",
                newName: "Identifications");

            migrationBuilder.RenameIndex(
                name: "IX_Identification_UserId",
                table: "Identifications",
                newName: "IX_Identifications_UserId");

            migrationBuilder.AddColumn<int>(
                name: "RelationshipStatusId",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SearchForId",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContentUrl",
                table: "Posts",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Numero",
                table: "Identifications",
                type: "varchar(14)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Identifications",
                table: "Identifications",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PublishDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(type: "varchar(400)", nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EducationalInstitutions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    NameInstitution = table.Column<string>(type: "varchar(150)", nullable: false),
                    GraduateYear = table.Column<DateTime>(nullable: true),
                    StillStudying = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationalInstitutions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EducationalInstitutions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Friends",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    UserFriendId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friends", x => new { x.UserId, x.UserFriendId });
                    table.ForeignKey(
                        name: "FK_Friends_Users_UserFriendId",
                        column: x => x.UserFriendId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Friends_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SearchFor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "varchar(15)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchFor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkCompanies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(type: "varchar(120)", nullable: false),
                    AdmissionDate = table.Column<DateTime>(nullable: false),
                    OutDate = table.Column<DateTime>(nullable: true),
                    CurrentJob = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkCompanies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkCompanies_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "RelationshipStatus",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "NotSpecified" },
                    { 2, "Single" },
                    { 3, "RelationShip" },
                    { 4, "Maried" }
                });

            migrationBuilder.InsertData(
                table: "SearchFor",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "NotSpecified" },
                    { 2, "Date" },
                    { 3, "Friendship" },
                    { 4, "RelationShip" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RelationshipStatusId",
                table: "Users",
                column: "RelationshipStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_SearchForId",
                table: "Users",
                column: "SearchForId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationalInstitutions_UserId",
                table: "EducationalInstitutions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Friends_UserFriendId",
                table: "Friends",
                column: "UserFriendId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkCompanies_UserId",
                table: "WorkCompanies",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Identifications_Users_UserId",
                table: "Identifications",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_RelationshipStatus_RelationshipStatusId",
                table: "Users",
                column: "RelationshipStatusId",
                principalTable: "RelationshipStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_SearchFor_SearchForId",
                table: "Users",
                column: "SearchForId",
                principalTable: "SearchFor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Identifications_Users_UserId",
                table: "Identifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_RelationshipStatus_RelationshipStatusId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_SearchFor_SearchForId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "EducationalInstitutions");

            migrationBuilder.DropTable(
                name: "Friends");

            migrationBuilder.DropTable(
                name: "SearchFor");

            migrationBuilder.DropTable(
                name: "WorkCompanies");

            migrationBuilder.DropIndex(
                name: "IX_Users_RelationshipStatusId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_SearchForId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Identifications",
                table: "Identifications");

            migrationBuilder.DeleteData(
                table: "RelationshipStatus",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RelationshipStatus",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RelationshipStatus",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RelationshipStatus",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "RelationshipStatusId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SearchForId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ContentUrl",
                table: "Posts");

            migrationBuilder.RenameTable(
                name: "Identifications",
                newName: "Identification");

            migrationBuilder.RenameIndex(
                name: "IX_Identifications_UserId",
                table: "Identification",
                newName: "IX_Identification_UserId");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "RelationshipStatus",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Numero",
                table: "Identification",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(14)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Identification",
                table: "Identification",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_RelationshipStatus_UserId",
                table: "RelationshipStatus",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Identification_Users_UserId",
                table: "Identification",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RelationshipStatus_Users_UserId",
                table: "RelationshipStatus",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
