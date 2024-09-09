using Larmo.Domain.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Larmo.Infrastructure.EntityConfigurations;

public class UserEntityConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasMany<IdentityUserRole<string>>()
            .WithOne()
            .HasForeignKey(userRole => userRole.UserId);

        builder.HasMany(user => user.UserPermissions)
            .WithOne(userPermission => userPermission.User)
            .HasForeignKey(userPermission => userPermission.UserId);

        builder.OwnsOne(user => user.RefreshToken, navigationBuilder =>
        {
            navigationBuilder.WithOwner()
                .HasForeignKey(t => t.UserId);

            navigationBuilder.ToTable("User.RefreshTokens");

            navigationBuilder.HasKey(t => t.Id);
        });

        //builder.Navigation(u => u.UserPermissions).AutoInclude(false);
    }
}