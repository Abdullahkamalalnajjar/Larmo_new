namespace Larmo.Domain.Domain;

public class Notification
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string MotherName { get; set; }
    public Gender Gender { get; set; }
    public MaritalStatus MaritalStatus { get; set; }
    public string Profession { get; set; }
    public string Employer { get; set; }
    public DateTime StartWorkDate { get; set; }
    public string IdentityNumber { get; set; }
    public DateTime IdentityIssueDate { get; set; }
    public DateTime IdentityExpiryDate { get; set; }
    public bool IsLibyanNationality { get; set; }
    public string Nationality { get; set; }
    public bool Resident { get; set; }
    public string PassportNumber { get; set; }
    public DateTime PassportNumberIssueDate { get; set; }
    public DateTime PassportNumberExpiryDate { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string City { get; set; }
    public string Area { get; set; }
    public string Street { get; set; }
    public string NearestMilestone { get; set; }
    public bool IsChecked { get; set; }
}