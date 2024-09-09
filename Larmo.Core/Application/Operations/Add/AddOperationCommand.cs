using Larmo.Domain.Domain;
using MediatR;

namespace Larmo.Core.Application.Operations.Add;

public sealed class AddOperationCommand : IRequest
{
    public OperationType OperationType { get; set; }
    public decimal Amount { get; set; }
    public string CurrencyType { get; set; }
    public DateTime Date { get; set; }
    public string Iban { get; set; }
    public string BeneficiaryName { get; set; }
    public string BeneficiaryCountry { get; set; }
    public string BeneficiaryCity { get; set; }
    public string BeneficiaryArea { get; set; }
    public string BeneficiaryNearestMilestone { get; set; }
    public string SourceOfFunds { get; set; }
    public string SendingParty { get; set; }
    public string ReceivingParty { get; set; }
    public string ClientProfession { get; set; }
    public string ClientIdentityNumber { get; set; }
    public string ClientCountry { get; set; }
    public string ClientCity { get; set; }
    public string ClientArea { get; set; }
    public string ClientNearestMilestone { get; set; }
    public string BeneficiaryClientRelationship { get; set; }
    public string BeneficiaryActivity { get; set; }
}