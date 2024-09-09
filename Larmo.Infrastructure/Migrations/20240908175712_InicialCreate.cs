using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Larmo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InicialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    MotherName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaritalStatus = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Profession = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Employer = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    StartWorkDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdentityNumber = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IdentityIssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdentityExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsLibyanNationality = table.Column<bool>(type: "bit", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Resident = table.Column<bool>(type: "bit", nullable: false),
                    PassportNumber = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    PassportNumberIssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PassportNumberExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    City = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Area = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    NearestMilestone = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IsChecked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Operations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OperationType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Amount = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CurrencyType = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Iban = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    BeneficiaryName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    BeneficiaryCountry = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    BeneficiaryCity = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    BeneficiaryArea = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    BeneficiaryNearestMilestone = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    SourceOfFunds = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    SendingParty = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ReceivingParty = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ClientProfession = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ClientIdentityNumber = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ClientCountry = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ClientCity = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ClientArea = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ClientNearestMilestone = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    BeneficiaryClientRelationship = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    BeneficiaryActivity = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DependOn = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModuleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permissions_Permissions_DependOn",
                        column: x => x.DependOn,
                        principalTable: "Permissions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User.RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpireOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User.RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User.RefreshTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPermissions",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PermissionId = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPermissions", x => new { x.UserId, x.PermissionId });
                    table.ForeignKey(
                        name: "FK_UserPermissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPermissions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "DependOn", "ModuleName", "Name" },
                values: new object[,]
                {
                    { "4a25dc3dff9541d1af2f827976e2afa5", null, "Notification", "CanAddNotification" },
                    { "87ba6d62cfb24b3eab65df07e26746c3", null, "Operation", "CanViewAllOperation" },
                    { "2a623fcb785a4267b0e0962f51b0ed3b", "4a25dc3dff9541d1af2f827976e2afa5", "Notification", "CanUpdateNotification" },
                    { "4484be5ffc38494fa9c13857308d9295", "87ba6d62cfb24b3eab65df07e26746c3", "Operation", "CanAddOperation" },
                    { "a1cab9f3edc646e5a93d68bed4e44fbd", "4a25dc3dff9541d1af2f827976e2afa5", "Notification", "CanViewAllNotification" },
                    { "ec26585332ca4aa998da73133ae4a5e4", "87ba6d62cfb24b3eab65df07e26746c3", "Operation", "CanUpdateOperation" },
                    { "edd67902e6554fe3bda19d495999304e", "87ba6d62cfb24b3eab65df07e26746c3", "Operation", "CanViewOperationDetails" },
                    { "5e30008eba3c4fa18edbc94ea6eb002e", "a1cab9f3edc646e5a93d68bed4e44fbd", "Notification", "CanViewNotificationDetails" },
                    { "9f78040e8cbb460598d83d0e21ed3b15", "a1cab9f3edc646e5a93d68bed4e44fbd", "Notification", "CanViewAllOwnedNotification" },
                    { "f5daa81825bb437a85285d32c54199d3", "a1cab9f3edc646e5a93d68bed4e44fbd", "Notification", "CanCheckNotification" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_DependOn",
                table: "Permissions",
                column: "DependOn");

            migrationBuilder.CreateIndex(
                name: "IX_User.RefreshTokens_UserId",
                table: "User.RefreshTokens",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserPermissions_PermissionId",
                table: "UserPermissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Operations");

            migrationBuilder.DropTable(
                name: "User.RefreshTokens");

            migrationBuilder.DropTable(
                name: "UserPermissions");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
