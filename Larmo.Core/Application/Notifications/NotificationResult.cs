namespace Larmo.Core.Application.Notifications;

public sealed record NotificationResult
{
    public int Id { get; init; }
    public string FullName { get; init; }
    public string MotherName { get; init; }
    public string Gender { get; init; }
    public string MaritalStatus { get; init; }
    public string Profession { get; init; }
    public string Employer { get; init; }
    public DateTime StartWorkDate { get; init; }
    public string IdentityNumber { get; init; }
    public DateTime IdentityIssueDate { get; init; }
    public DateTime IdentityExpiryDate { get; init; }
    public bool IsLibyanNationality { get; init; }
    public string Nationality { get; init; }
    public bool Resident { get; init; }
    public string PassportNumber { get; init; }
    public DateTime PassportNumberIssueDate { get; init; }
    public DateTime PassportNumberExpiryDate { get; init; }
    public string PhoneNumber { get; init; }
    public string Email { get; init; }
    public string City { get; init; }
    public string Area { get; init; }
    public string Street { get; init; }
    public string NearestMilestone { get; init; }
    public bool IsChecked { get; init; }
}