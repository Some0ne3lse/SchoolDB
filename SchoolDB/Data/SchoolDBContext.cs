using Microsoft.EntityFrameworkCore;
using SchoolDB.Models;

namespace SchoolDB.Data;

public class SchoolDBContext : DbContext
{
    public DbSet<Group> Groups { get; set; }

    public DbSet<Mark> Marks { get; set; }
    
    public DbSet<Student> Students { get; set; }

    public DbSet<Subject> Subjects { get; set; }

    public DbSet<Teacher> Teachers { get; set; }
}