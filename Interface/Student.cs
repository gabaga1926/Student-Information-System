namespace Interface;

public class Student
{
    public string StudentId { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string FullName => $"{FirstName} {LastName}".Trim();
    public string Gender { get; set; } = string.Empty;
    public int YearLevel { get; set; }
    public string Program { get; set; } = string.Empty;
    public string ContactNumber { get; set; } = string.Empty;
}
