using System.ComponentModel.DataAnnotations;

namespace SchoolDB.Models;

public class Subject
{
    public int Id { get; set; }
    
    [MaxLength(50)]
    public string Title { get; set; } = null!;

    public List<Mark> Marks { get; set; }

    public List<TeacherSubject> TeacherSubjects { get; set; }
    
    public Subject()
    {
        Marks = new List<Mark>();
        TeacherSubjects = new List<TeacherSubject>();
    }

}