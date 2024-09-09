using FluentValidation;

namespace Larmo.Core.Application.Operations.Add;

public sealed class AddOperationCommandValidator : AbstractValidator<AddOperationCommand>
{
    public AddOperationCommandValidator()
    {
        RuleFor(c => c.OperationType)
            .IsInEnum()
            .WithMessage("Operation Type is required");

        RuleFor(c => c.CurrencyType)
            .NotEmpty()
            .WithMessage("CurrencyType is required");

        RuleFor(c => c.Iban)
            .NotEmpty()
            .WithMessage("IBAN is required");

        RuleFor(c => c.BeneficiaryName)
            .NotEmpty()
            .WithMessage("Beneficiary Name is required");

        RuleFor(c => c.BeneficiaryCountry)
            .NotEmpty()
            .WithMessage("Beneficiary Country is required");

        RuleFor(c => c.BeneficiaryCity)
            .NotEmpty()
            .WithMessage("Beneficiary City is required");

        RuleFor(c => c.BeneficiaryArea)
            .NotEmpty()
            .WithMessage("Beneficiary Area is required");

        RuleFor(c => c.BeneficiaryNearestMilestone)
            .NotEmpty()
            .WithMessage("Beneficiary Nearest Milestone is required");

        RuleFor(c => c.SourceOfFunds)
            .NotEmpty()
            .WithMessage("Source Of Funds is required");

        RuleFor(c => c.SendingParty)
            .NotEmpty()
            .WithMessage("Sending Party is required");

        RuleFor(c => c.ReceivingParty)
            .NotEmpty()
            .WithMessage("Receiving Party is required");

        RuleFor(c => c.ClientProfession)
            .NotEmpty()
            .WithMessage("Client Profession is required");

        RuleFor(c => c.ClientIdentityNumber)
            .NotEmpty()
            .WithMessage("Client Identity Number is required");

        RuleFor(c => c.ClientCountry)
            .NotEmpty()
            .WithMessage("Client Country is required");

        RuleFor(c => c.ClientCity)
            .NotEmpty()
            .WithMessage("Client City is required");

        RuleFor(c => c.ClientArea)
            .NotEmpty()
            .WithMessage("Client Area is required");

        RuleFor(c => c.ClientNearestMilestone)
            .NotEmpty()
            .WithMessage("Client Nearest Milestone is required");

        RuleFor(c => c.BeneficiaryClientRelationship)
            .NotEmpty()
            .WithMessage("Beneficiary Client Relationship is required");

        RuleFor(c => c.BeneficiaryActivity)
            .NotEmpty()
            .WithMessage("Beneficiary Activity is required");

        RuleFor(c => c.Date)
            .NotEmpty()
            .WithMessage("Date is required");

        RuleFor(c => c.Amount)
            .GreaterThan(0)
            .WithMessage("Amount should greater than zero");
    }
}