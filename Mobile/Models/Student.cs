namespace StudentSystem.Mobile.Models;

public sealed class Student
{
    public string StudentId { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;
    public int YearLevel { get; set; }
    public string Program { get; set; } = string.Empty;
    public string? ContactNumber { get; set; }
}
