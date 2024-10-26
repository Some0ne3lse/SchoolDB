using Microsoft.EntityFrameworkCore;
using SchoolDB.Models;

namespace SchoolDB.Data;

public class SchoolDbContext : DbContext
{
    public DbSet<Group> Groups { get; set; }

    public DbSet<Mark> Marks { get; set; }
    
    public DbSet<Student> Students { get; set; }

    public DbSet<Subject> Subjects { get; set; }

    public DbSet<Teacher> Teachers { get; set; }
    
    public string DbPath { get; }

    public SchoolDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Combine(path, "school.db");
        Console.WriteLine($"Database path: {DbPath}");
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}