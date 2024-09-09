using Larmo.Domain.Domain;
using Larmo.Domain.Domain.Identity;
using Larmo.Shared.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Larmo.Infrastructure.EntityConfigurations;

public class PermissionEntityConfiguration : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.ToTable("Permissions");

        builder.Property(g => g.Id)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(g => g.DependOn)
            .HasMaxLength(100);

        builder.Property(g => g.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(r => r.ModuleName)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasOne(p => p.Parent)
            .WithMany()
            .HasForeignKey(p => p.DependOn);

        builder.HasMany<UserPermission>()
            .WithOne(userPermission => userPermission.Permission)
            .HasForeignKey(userPermission => userPermission.PermissionId);

        builder.HasData(GetRoles());
    }

    private static Permission[] GetRoles() =>
    [
        // operations permissions
        Permission.Create(id: Guid.Parse("87ba6d62-cfb2-4b3e-ab65-df07e26746c3").ToString("N"),
            name: PermissionNames.CanViewAllOperation,
            moduleName: nameof(Operation),
            dependOn: null),

        Permission.Create(id: Guid.Parse("4484be5f-fc38-494f-a9c1-3857308d9295").ToString("N"),
            name: PermissionNames.CanAddOperation,
            moduleName: nameof(Operation),
            dependOn: Guid.Parse("87ba6d62-cfb2-4b3e-ab65-df07e26746c3").ToString("N")),

        Permission.Create(id: Guid.Parse("edd67902-e655-4fe3-bda1-9d495999304e").ToString("N"),
            name: PermissionNames.CanViewOperationDetails,
            moduleName: nameof(Operation),
            dependOn: Guid.Parse("87ba6d62-cfb2-4b3e-ab65-df07e26746c3").ToString("N")),

        Permission.Create(id: Guid.Parse("ec265853-32ca-4aa9-98da-73133ae4a5e4").ToString("N"),
            name: PermissionNames.CanUpdateOperation,
            moduleName: nameof(Operation),
            dependOn: Guid.Parse("87ba6d62-cfb2-4b3e-ab65-df07e26746c3").ToString("N")),

        // notifications permissions
        Permission.Create(id: Guid.Parse("4a25dc3d-ff95-41d1-af2f-827976e2afa5").ToString("N"),
            name: PermissionNames.CanAddNotification,
            moduleName: nameof(Notification),
            dependOn: null),

        Permission.Create(id: Guid.Parse("a1cab9f3-edc6-46e5-a93d-68bed4e44fbd").ToString("N"),
            name: PermissionNames.CanViewAllNotification,
            moduleName: nameof(Notification),
            dependOn: Guid.Parse("4a25dc3d-ff95-41d1-af2f-827976e2afa5").ToString("N")),

        Permission.Create(id: Guid.Parse("2a623fcb-785a-4267-b0e0-962f51b0ed3b").ToString("N"),
            name: PermissionNames.CanUpdateNotification,
            moduleName: nameof(Notification),
            dependOn: Guid.Parse("4a25dc3d-ff95-41d1-af2f-827976e2afa5").ToString("N")),

        Permission.Create(id: Guid.Parse("5e30008e-ba3c-4fa1-8edb-c94ea6eb002e").ToString("N"),
            name: PermissionNames.CanViewNotificationDetails,
            moduleName: nameof(Notification),
            dependOn: Guid.Parse("a1cab9f3-edc6-46e5-a93d-68bed4e44fbd").ToString("N")),

        Permission.Create(id: Guid.Parse("9f78040e-8cbb-4605-98d8-3d0e21ed3b15").ToString("N"),
            name: PermissionNames.CanViewAllOwnedNotification,
            moduleName: nameof(Notification),
            dependOn: Guid.Parse("a1cab9f3-edc6-46e5-a93d-68bed4e44fbd").ToString("N")),

        Permission.Create(id: Guid.Parse("f5daa818-25bb-437a-8528-5d32c54199d3").ToString("N"),
            name: PermissionNames.CanCheckNotification,
            moduleName: nameof(Notification),
            dependOn: Guid.Parse("a1cab9f3-edc6-46e5-a93d-68bed4e44fbd").ToString("N"))
    ];
}