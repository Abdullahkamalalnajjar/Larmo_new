using Larmo.Core.Repository;
using Larmo.Domain.Domain;
using MediatR;

namespace Larmo.Core.Application.Notifications.Add;

internal sealed class AddNotificationCommandHandler(INotificationRepository notificationRepository)
    : IRequestHandler<AddNotificationCommand>
{
    public async Task Handle(AddNotificationCommand request, CancellationToken cancellationToken)
    {
        var notification = new Notification
        {
            Area = request.Area,
            City = request.City,
            Email = request.Email,
            Employer = request.Employer,
            FullName = request.FullName,
            Gender = request.Gender,
            IdentityExpiryDate = request.IdentityExpiryDate,
            IdentityIssueDate = request.IdentityIssueDate,
            IdentityNumber = request.IdentityNumber,
            IsLibyanNationality = request.IsLibyanNationality,
            MaritalStatus = request.MaritalStatus,
            MotherName = request.MotherName,
            Nationality = request.IsLibyanNationality ? "" : request.Nationality,
            NearestMilestone = request.NearestMilestone,
            PassportNumber = request.PassportNumber,
            PassportNumberExpiryDate = request.PassportNumberExpiryDate,
            PassportNumberIssueDate = request.PassportNumberIssueDate,
            PhoneNumber = request.PhoneNumber,
            Profession = request.Profession,
            Street = request.Street,
            StartWorkDate = request.StartWorkDate,
            Resident = request.Resident
        };

        await notificationRepository.AddAsync(notification, cancellationToken);
    }
}