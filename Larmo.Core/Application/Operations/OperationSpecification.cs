using Ardalis.Specification;
using Larmo.Domain.Domain;

namespace Larmo.Core.Application.Operations;

public sealed class OperationSpecification : Specification<Operation, OperationResult>
{
    public OperationSpecification()
    {
        Query.AsNoTracking();

        Query.Select(o => new OperationResult
        {
            Amount = o.Amount,
            BeneficiaryActivity = o.BeneficiaryActivity,
            BeneficiaryArea = o.BeneficiaryArea,
            BeneficiaryCity = o.BeneficiaryCity,
            BeneficiaryClientRelationship = o.BeneficiaryClientRelationship,
            BeneficiaryCountry = o.BeneficiaryCountry,
            BeneficiaryName = o.BeneficiaryName,
            BeneficiaryNearestMilestone = o.BeneficiaryNearestMilestone,
            ClientArea = o.ClientArea,
            ClientCity = o.ClientCity,
            ClientCountry = o.ClientCountry,
            ClientIdentityNumber = o.ClientIdentityNumber,
            ClientNearestMilestone = o.ClientNearestMilestone,
            ClientProfession = o.ClientProfession,
            CurrencyType = o.CurrencyType,
            Date = o.Date,
            Iban = o.Iban,
            Id = o.Id,
            OperationType = o.OperationType,
            ReceivingParty = o.ReceivingParty,
            SendingParty = o.SendingParty,
            SourceOfFunds = o.SourceOfFunds
        });
    }

    public OperationSpecification(int operationId)
    {
        Query.Where(o => o.Id == operationId).AsNoTracking();

        Query.Select(o => new OperationResult
        {
            Amount = o.Amount,
            BeneficiaryActivity = o.BeneficiaryActivity,
            BeneficiaryArea = o.BeneficiaryArea,
            BeneficiaryCity = o.BeneficiaryCity,
            BeneficiaryClientRelationship = o.BeneficiaryClientRelationship,
            BeneficiaryCountry = o.BeneficiaryCountry,
            BeneficiaryName = o.BeneficiaryName,
            BeneficiaryNearestMilestone = o.BeneficiaryNearestMilestone,
            ClientArea = o.ClientArea,
            ClientCity = o.ClientCity,
            ClientCountry = o.ClientCountry,
            ClientIdentityNumber = o.ClientIdentityNumber,
            ClientNearestMilestone = o.ClientNearestMilestone,
            ClientProfession = o.ClientProfession,
            CurrencyType = o.CurrencyType,
            Date = o.Date,
            Iban = o.Iban,
            Id = o.Id,
            OperationType = o.OperationType,
            ReceivingParty = o.ReceivingParty,
            SendingParty = o.SendingParty,
            SourceOfFunds = o.SourceOfFunds
        });
    }
}