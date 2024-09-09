using Ardalis.Specification;
using Larmo.Domain.Domain;

namespace Larmo.Core.Application.Notifications;

public sealed class NotificationSpecification : Specification<Notification, NotificationResult>
{
    public NotificationSpecification()
    {
        Query.AsNoTracking();

        Query.Select(n => new NotificationResult
        {
            Area = n.Area,
            City = n.City,
            Email = n.Email,
            Employer = n.Employer,
            FullName = n.FullName,
            Gender = n.Gender.ToString(),
            IdentityExpiryDate = n.IdentityExpiryDate,
            IdentityIssueDate = n.IdentityIssueDate,
            IdentityNumber = n.IdentityNumber,
            IsLibyanNationality = n.IsLibyanNationality,
            MaritalStatus = n.MaritalStatus.ToString(),
            MotherName = n.MotherName,
            Nationality = n.Nationality,
            NearestMilestone = n.NearestMilestone,
            PassportNumber = n.PassportNumber,
            PassportNumberExpiryDate = n.PassportNumberExpiryDate,
            PassportNumberIssueDate = n.PassportNumberIssueDate,
            PhoneNumber = n.PhoneNumber,
            Profession = n.Profession,
            Street = n.Street,
            StartWorkDate = n.StartWorkDate,
            Resident = n.Resident,
            Id = n.Id,
            IsChecked = n.IsChecked
        });
    }

    public NotificationSpecification(int notificationId)
    {
        Query.Where(n => n.Id == notificationId).AsNoTracking();

        Query.Select(n => new NotificationResult
        {
            Area = n.Area,
            City = n.City,
            Email = n.Email,
            Employer = n.Employer,
            FullName = n.FullName,
            Gender = n.Gender.ToString(),
            IdentityExpiryDate = n.IdentityExpiryDate,
            IdentityIssueDate = n.IdentityIssueDate,
            IdentityNumber = n.IdentityNumber,
            IsLibyanNationality = n.IsLibyanNationality,
            MaritalStatus = n.MaritalStatus.ToString(),
            MotherName = n.MotherName,
            Nationality = n.Nationality,
            NearestMilestone = n.NearestMilestone,
            PassportNumber = n.PassportNumber,
            PassportNumberExpiryDate = n.PassportNumberExpiryDate,
            PassportNumberIssueDate = n.PassportNumberIssueDate,
            PhoneNumber = n.PhoneNumber,
            Profession = n.Profession,
            Street = n.Street,
            StartWorkDate = n.StartWorkDate,
            Resident = n.Resident,
            Id = n.Id,
            IsChecked = n.IsChecked
        });
    }
}