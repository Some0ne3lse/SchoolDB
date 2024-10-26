using System.ComponentModel.DataAnnotations;

namespace SchoolDB.Models;

public class Group
{
    public int Id { get; set; }

    [MaxLength(20)]
    public string Name { get; set; } = null!;

    public List<Student> Students { get; set; } = new List<Student>();
}