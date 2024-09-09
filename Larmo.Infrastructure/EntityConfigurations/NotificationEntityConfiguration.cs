using Larmo.Domain.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Larmo.Infrastructure.EntityConfigurations;

public class NotificationEntityConfiguration : IEntityTypeConfiguration<Notification>
{
    public void Configure(EntityTypeBuilder<Notification> builder)
    {
        builder.ToTable("Notifications");

        builder.Property(l => l.City).IsRequired().HasMaxLength(250);
        builder.Property(l => l.Area).IsRequired().HasMaxLength(250);
        builder.Property(l => l.NearestMilestone).IsRequired().HasMaxLength(250);
        builder.Property(l => l.Email).IsRequired().HasMaxLength(250);
        builder.Property(l => l.Employer).IsRequired().HasMaxLength(250);
        builder.Property(l => l.FullName).IsRequired().HasMaxLength(250);
        builder.Property(l => l.MotherName).IsRequired().HasMaxLength(250);
        builder.Property(l => l.Profession).IsRequired().HasMaxLength(250);
        builder.Property(l => l.IdentityNumber).IsRequired().HasMaxLength(250);
        builder.Property(l => l.Nationality).IsRequired().HasMaxLength(250);
        builder.Property(l => l.PassportNumber).IsRequired().HasMaxLength(250);
        builder.Property(l => l.PhoneNumber).IsRequired().HasMaxLength(250);
        builder.Property(l => l.Street).IsRequired().HasMaxLength(250);

        builder.Property(l => l.Gender).IsRequired().HasConversion(
                x => x.ToString(),
                x => Enum.Parse<Gender>(x))
            .HasMaxLength(100);

        builder.Property(l => l.MaritalStatus).IsRequired().HasConversion(
                x => x.ToString(),
                x => Enum.Parse<MaritalStatus>(x))
            .HasMaxLength(100);
    }
}