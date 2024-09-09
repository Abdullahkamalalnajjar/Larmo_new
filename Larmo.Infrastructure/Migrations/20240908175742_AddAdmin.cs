using Larmo.Domain.Domain.Identity;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Larmo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // add admin user
            migrationBuilder.InsertData(
                table: "Users",
                columns:
                [
                    nameof(User.Id),
                    nameof(User.CreatedOn),
                    nameof(User.UserName),
                    nameof(User.NormalizedUserName),
                    nameof(User.Email),
                    nameof(User.NormalizedEmail),
                    nameof(User.PasswordHash),
                    nameof(User.SecurityStamp),
                    nameof(User.EmailConfirmed),
                    nameof(User.PhoneNumberConfirmed),
                    nameof(User.TwoFactorEnabled),
                    nameof(User.LockoutEnabled),
                    nameof(User.AccessFailedCount)
                ],
                values:
                [
                    "e93befcab78c4473afaae500ce652bf6",
                    DateTime.UtcNow,
                    "admin",
                    "ADMIN",
                    "admin@admin.com",
                    "ADMIN@ADMIN.COM",
                    "AQAAAAIAAYagAAAAEGQimnytGiwkqdN0Bn2keS0PNxGtGg2ZjGUJDnqcyx+uYo3SUAv7+wOFiNG/jOaWLQ==",
                    "RWUVB7UU7QT6UKETGP4XTKJMCVL32ROB",
                    true,
                    true,
                    false,
                    false,
                    0
                ]);

            // add admin role
            migrationBuilder.InsertData(
                table: "Roles",
                columns:
                [
                    "Id",
                    "Name",
                    "NormalizedName"
                ],
                values:
                [
                    "dc7db4360cbf4e58819566162491bd6c",
                    "Admin",
                    "ADMIN"
                ]);

            // add user role
            migrationBuilder.InsertData(
                table: "UserRoles",
                columns:
                [
                    "UserId",
                    "RoleId"
                ],
                values:
                [
                    "e93befcab78c4473afaae500ce652bf6",
                    "dc7db4360cbf4e58819566162491bd6c",
                ]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // remove admin user
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: nameof(User.Id),
                keyValue: "e93befcab78c4473afaae500ce652bf6"
            );

            // remove admin role
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "dc7db4360cbf4e58819566162491bd6c"
            );

            // remove user role
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: ["UserId", "RoleId"],
                keyValues: ["e93befcab78c4473afaae500ce652bf6", "dc7db4360cbf4e58819566162491bd6c"]
            );
        }
    }
}
