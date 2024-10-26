using System.ComponentModel.DataAnnotations;

namespace SchoolDB.Models;

public class Subject
{
    public int Id { get; set; }
    
    [MaxLength(50)]
    public string Title { get; set; } = null!;

    public List<Mark> Marks { get; set; } = new List<Mark>();

    public List<Teacher> Teachers { get; set; } = new List<Teacher>();

}