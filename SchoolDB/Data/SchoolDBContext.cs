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
    
    public DbSet<TeacherSubject> TeacherSubjects { get; set; }
    
    // There are more elegant ways of doing the following seed, but I wanted to show that I understood the recordings

    public static void SeedDatabase()
        {
            using (var db = new SchoolDbContext())
            {
                db.Database.EnsureCreated();
                
                var groupA = db.Groups.FirstOrDefault(g => g.Name == "Group A");
                if (groupA == null)
                {
                    groupA = new Group { Name = "Group A" };
                    db.Groups.Add(groupA);
                }

                var groupB = db.Groups.FirstOrDefault(g => g.Name == "Group B");
                if (groupB == null)
                {
                    groupB = new Group { Name = "Group B" };
                    db.Groups.Add(groupB);
                }
                db.SaveChanges();

                var programming = db.Subjects.FirstOrDefault(s => s.Title == "Programming");
                if (programming == null)
                {
                    programming = new Subject { Title = "Programming" };
                    db.Subjects.Add(programming);
                }

                var physics = db.Subjects.FirstOrDefault(s => s.Title == "Physics");
                if (physics == null)
                {
                    physics = new Subject { Title = "Physics" };
                    db.Subjects.Add(physics);
                }
                
                db.SaveChanges();
            
                var teacher1 = db.Teachers.FirstOrDefault(t => t.FirstName == "Daniel" && t.LastName == "Jackson");
                if (teacher1 == null)
                {
                    teacher1 = new Teacher { FirstName = "Daniel", LastName = "Jackson" };
                    db.Teachers.Add(teacher1);
                }

                var teacher2 = db.Teachers.FirstOrDefault(t => t.FirstName == "Jack" && t.LastName == "O'Neil");
                if (teacher2 == null)
                {
                    teacher2 = new Teacher { FirstName = "Jack", LastName = "O'Neil" };
                    db.Teachers.Add(teacher2);
                }
                
                db.SaveChanges();

                
                var student1 = db.Students.FirstOrDefault(s => s.FirstName == "Samantha" && s.LastName == "Carter");
                if (student1 == null)
                {
                    student1 = new Student { FirstName = "Samantha", LastName = "Carter", GroupId = groupA.Id };
                    db.Students.Add(student1);
                }

                var student2 = db.Students.FirstOrDefault(s => s.FirstName == "Teal'c" && s.LastName == "Of Chulak");
                if (student2 == null)
                {
                    student2 = new Student { FirstName = "Teal'c", LastName = "Of Chulak", GroupId = groupB.Id };
                    db.Students.Add(student2);
                }

                db.SaveChanges();
                
                var mark1 = db.Marks.FirstOrDefault(m => m.StudentId == student1.Id && m.SubjectId == programming.Id);
                if (mark1 == null)
                {
                    db.Marks.Add(new Mark { Date = DateTime.Now, MarkReceived = 90, StudentId = student1.Id, SubjectId = programming.Id });
                }

                var mark2 = db.Marks.FirstOrDefault(m => m.StudentId == student2.Id && m.SubjectId == physics.Id);
                if (mark2 == null)
                {
                    db.Marks.Add(new Mark { Date = DateTime.Now, MarkReceived = 90, StudentId = student2.Id, SubjectId = physics.Id });
                }
                
                var teacherSubject1 = db.TeacherSubjects.FirstOrDefault(ts => ts.TeacherId == teacher1.Id && ts.SubjectId == programming.Id);
                if (teacherSubject1 == null)
                {
                    db.TeacherSubjects.Add(new TeacherSubject { TeacherId = teacher1.Id, SubjectId = programming.Id });
                }

                var teacherSubject2 = db.TeacherSubjects.FirstOrDefault(ts => ts.TeacherId == teacher2.Id && ts.SubjectId == physics.Id);
                if (teacherSubject2 == null)
                {
                    db.TeacherSubjects.Add(new TeacherSubject { TeacherId = teacher2.Id, SubjectId = physics.Id });
                }

                db.SaveChanges();
            }
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
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TeacherSubject>()
            .HasKey(ts => new { ts.TeacherId, ts.SubjectId });

        base.OnModelCreating(modelBuilder);
    }
}