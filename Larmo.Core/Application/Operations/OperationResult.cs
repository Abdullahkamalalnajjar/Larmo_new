namespace Larmo.Core.Application.Operations;

public record OperationResult
{
    public int Id { get; init; }
    public string OperationType { get; init; }
    public string Amount { get; init; }
    public string CurrencyType { get; init; }
    public string Date { get; init; }
    public string Iban { get; init; }
    public string BeneficiaryName { get; init; }
    public string BeneficiaryCountry { get; init; }
    public string BeneficiaryCity { get; init; }
    public string BeneficiaryArea { get; init; }
    public string BeneficiaryNearestMilestone { get; init; }
    public string SourceOfFunds { get; init; }
    public string SendingParty { get; init; }
    public string ReceivingParty { get; init; }
    public string ClientProfession { get; init; }
    public string ClientIdentityNumber { get; init; }
    public string ClientCountry { get; init; }
    public string ClientCity { get; init; }
    public string ClientArea { get; init; }
    public string ClientNearestMilestone { get; init; }
    public string BeneficiaryClientRelationship { get; init; }
    public string BeneficiaryActivity { get; init; }
}