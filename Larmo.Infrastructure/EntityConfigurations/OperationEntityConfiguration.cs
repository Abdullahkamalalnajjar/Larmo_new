using Larmo.Domain.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Larmo.Infrastructure.EntityConfigurations;

public class OperationEntityConfiguration : IEntityTypeConfiguration<Operation>
{
    public void Configure(EntityTypeBuilder<Operation> builder)
    {
        builder.ToTable("Operations");

        builder.Property(l => l.Amount).IsRequired().HasMaxLength(250);
        builder.Property(l => l.BeneficiaryActivity).IsRequired().HasMaxLength(250);
        builder.Property(l => l.BeneficiaryArea).IsRequired().HasMaxLength(250);
        builder.Property(l => l.BeneficiaryCity).IsRequired().HasMaxLength(250);
        builder.Property(l => l.BeneficiaryCountry).IsRequired().HasMaxLength(250);
        builder.Property(l => l.BeneficiaryNearestMilestone).IsRequired().HasMaxLength(250);
        builder.Property(l => l.BeneficiaryClientRelationship).IsRequired().HasMaxLength(250);
        builder.Property(l => l.BeneficiaryName).IsRequired().HasMaxLength(250);
        builder.Property(l => l.ClientArea).IsRequired().HasMaxLength(250);
        builder.Property(l => l.ClientCity).IsRequired().HasMaxLength(250);
        builder.Property(l => l.ClientCountry).IsRequired().HasMaxLength(250);
        builder.Property(l => l.ClientNearestMilestone).IsRequired().HasMaxLength(250);
        builder.Property(l => l.ClientProfession).IsRequired().HasMaxLength(250);
        builder.Property(l => l.ClientIdentityNumber).IsRequired().HasMaxLength(250);
        builder.Property(l => l.CurrencyType).IsRequired().HasMaxLength(250);
        builder.Property(l => l.Iban).IsRequired().HasMaxLength(250);
        builder.Property(l => l.ReceivingParty).IsRequired().HasMaxLength(250);
        builder.Property(l => l.SendingParty).IsRequired().HasMaxLength(250);
        builder.Property(l => l.SourceOfFunds).IsRequired().HasMaxLength(250);
        builder.Property(l => l.OperationType).IsRequired().HasMaxLength(100);
        builder.Property(l => l.Date).IsRequired().HasMaxLength(100);
    }
}