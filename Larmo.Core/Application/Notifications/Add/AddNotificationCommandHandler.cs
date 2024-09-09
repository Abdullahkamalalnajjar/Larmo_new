using Larmo.Core.Application.Notifications.Add;
using Larmo.Core.Repository;
using Larmo.Domain.Domain;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

internal sealed class AddNotificationCommandHandler : IRequestHandler<AddNotificationCommand>
{
    private readonly INotificationRepository _notificationRepository;

    // حقن التبعيات
    public AddNotificationCommandHandler(INotificationRepository notificationRepository, IWebHostEnvironment webHostEnvironment)
    {
        _notificationRepository=notificationRepository;
    }

    public async Task Handle(AddNotificationCommand request, CancellationToken cancellationToken)
    {

        var filePath = SaveFile(request.File, "Images");
        var notification = new Notification
        {
            Area=request.Area,
            City=request.City,
            Email=request.Email,
            Employer=request.Employer,
            FullName=request.FullName,
            Gender=request.Gender,
            IdentityExpiryDate=request.IdentityExpiryDate,
            IdentityIssueDate=request.IdentityIssueDate,
            IdentityNumber=request.IdentityNumber,
            IsLibyanNationality=request.IsLibyanNationality,
            MaritalStatus=request.MaritalStatus,
            MotherName=request.MotherName,
            Nationality=request.IsLibyanNationality ? "" : request.Nationality,
            NearestMilestone=request.NearestMilestone,
            PassportNumber=request.PassportNumber,
            PassportNumberExpiryDate=request.PassportNumberExpiryDate,
            PassportNumberIssueDate=request.PassportNumberIssueDate,
            PhoneNumber=request.PhoneNumber,
            Profession=request.Profession,
            Street=request.Street,
            StartWorkDate=request.StartWorkDate,
            Resident=request.Resident,
            FilePath=filePath 
        };

        await _notificationRepository.AddAsync(notification, cancellationToken);

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

