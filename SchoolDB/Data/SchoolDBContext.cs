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

    public static void SeedDataBase()
    {
        using var db = new SchoolDbContext();
        db.Database.EnsureCreated();

        var g1Exists = db.Groups.FirstOrDefault(g => g.Name == "GroupTest");
        if (g1Exists == null)
        {
            Group g1 = new Group() { Name = "GroupTest" };
            db.Groups.Add(g1);
        }

        var st1Exists = db.Students.FirstOrDefault(st => st.FirstName == "Testi" && st.LastName == "Test" && st.GroupId == g1Exists.Id);
        if (st1Exists == null)
        {
            Student st1 = new Student() { FirstName = "Testi", LastName = "Test", GroupId = g1Exists.Id};
            db.Students.Add(st1);
        }

        var su1Exists = db.Subjects.FirstOrDefault(su => su.Title == "SubjectTest");
        if (su1Exists == null)
        {
            Subject su1 = new Subject() { Title = "SubjectTest" };
            db.Subjects.Add(su1);
        }

        var t1Exists = db.Teachers.FirstOrDefault(t => t.FirstName == "Teacher" && t.LastName == "Test");
        if (t1Exists == null)
        {
            Teacher t1 = new Teacher() { FirstName = "Teacher", LastName = "Test" };
            db.Teachers.Add(t1);
        }

        var m1Exists = db.Marks.FirstOrDefault(m => m.StudentId == st1Exists.Id && m.SubjectId == su1Exists.Id && m.MarkReceived == 90);
        if (m1Exists == null)
        {
            Mark m1 = new Mark() { Date = DateTime.Now, StudentId = st1Exists.Id, SubjectId = su1Exists.Id, MarkReceived = 90 };
            db.Marks.Add(m1);

        }
        db.SaveChanges();

    }
    
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