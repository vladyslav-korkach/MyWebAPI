using Microsoft.EntityFrameworkCore;
using MyWebAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI.Data
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedAsync(ApplicationDbContext context)
        {
            if (!context.Students.Any())
            {
                var students = new List<Student>
                {
                    new Student { Name = "Alice" },
                    new Student { Name = "Bob" }
                };

                var subjects = new List<Subject>
                {
                    new Subject { Name = "Math" },
                    new Subject { Name = "Science" }
                };

                context.Students.AddRange(students);
                context.Subjects.AddRange(subjects);
                await context.SaveChangesAsync();

                var studentSubjects = new List<StudentSubject>
                {
                    new StudentSubject { StudentId = students[0].Id, SubjectId = subjects[0].Id },
                    new StudentSubject { StudentId = students[0].Id, SubjectId = subjects[1].Id },
                    new StudentSubject { StudentId = students[1].Id, SubjectId = subjects[0].Id }
                };

                context.StudentSubjects.AddRange(studentSubjects);
                await context.SaveChangesAsync();
            }
        }
    }
}