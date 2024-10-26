namespace SchoolDB.Models;

public class Student
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int GroupId { get; set; }

    public Group Group { get; set; } = null!;

    public List<Mark> Marks { get; set; } = new List<Mark>();

}