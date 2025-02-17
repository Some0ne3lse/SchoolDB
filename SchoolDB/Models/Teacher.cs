using System.ComponentModel.DataAnnotations;

namespace SchoolDB.Models;

public class Teacher
{
    public int Id { get; set; }

    [MaxLength(100)]
    public string FirstName { get; set; } = null!;

    [MaxLength(100)]
    public string LastName { get; set; } = null!;
    
    public List<TeacherSubject> TeacherSubjects { get; set; }

    public Teacher()
    {
        TeacherSubjects = new List<TeacherSubject>();
    }
}