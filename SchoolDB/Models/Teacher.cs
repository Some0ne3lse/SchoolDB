namespace SchoolDB.Models;

public class Teacher
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public List<Subject> Subjects { get; set; } = new List<Subject>();
}