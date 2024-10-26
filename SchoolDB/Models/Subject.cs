namespace SchoolDB.Models;

public class Subject
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;

    public List<Mark> Marks { get; set; } = new List<Mark>();

    public List<Teacher> Teachers { get; set; } = new List<Teacher>();

}