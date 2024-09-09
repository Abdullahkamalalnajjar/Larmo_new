using Larmo.Core.Repository;
using Larmo.Domain.Domain;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Larmo.Core.Application.Operations.Add;

internal sealed class AddOperationCommandHandler(IOperationRepository operationRepository)
    : IRequestHandler<AddOperationCommand>
{
    public async Task Handle(AddOperationCommand request, CancellationToken cancellationToken)
    {
        var filePath = SaveFile(request.FilePath, "Images");

        var operation = new Operation
        {
            BeneficiaryActivity = request.BeneficiaryActivity,
            BeneficiaryArea = request.BeneficiaryArea,
            BeneficiaryCity = request.BeneficiaryCity,
            BeneficiaryClientRelationship = request.BeneficiaryClientRelationship,
            BeneficiaryCountry = request.BeneficiaryCountry,
            BeneficiaryName = request.BeneficiaryName,
            BeneficiaryNearestMilestone = request.BeneficiaryNearestMilestone,
            ClientArea = request.ClientArea,
            ClientCity = request.ClientCity,
            ClientCountry = request.ClientCountry,
            ClientIdentityNumber = request.ClientIdentityNumber,
            ClientNearestMilestone = request.ClientNearestMilestone,
            ClientProfession = request.ClientProfession,
            CurrencyType = request.CurrencyType,
            ReceivingParty = request.ReceivingParty,
            SendingParty = request.SendingParty,
            SourceOfFunds = request.SourceOfFunds,
            Iban = request.Iban,
            FilePath =filePath,
            
        };

        operation.SetAmount(request.Amount);
        operation.SetDate(request.Date);
        operation.SetOperationType(request.OperationType);

        await operationRepository.AddAsync(operation, cancellationToken);
    }

    private string SaveFile(IFormFile file, string folderName)
    {
        if ( file==null||file.Length==0 )
            return null;

        // Define the path to save the file
        string uploadsFolder = Path.Combine("wwwroot", folderName);
        string uniqueFileName = Guid.NewGuid().ToString()+"_"+file.FileName;

        string filePath = Path.Combine(uploadsFolder, uniqueFileName);

        // Ensure the directory exists
        Directory.CreateDirectory(uploadsFolder);

        // Save the file
        using ( var fileStream = new FileStream(filePath, FileMode.Create) )
        {
            file.CopyTo(fileStream);
        }

        string serverBaseUrl = "http://larmo.tryasp.net";
        string relativePath = Path.Combine(folderName, uniqueFileName);

        return $"{serverBaseUrl}/{relativePath.Replace("\\", "/")}";
    }
}