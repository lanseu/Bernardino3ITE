using Bernardino3ITE.Models;
using Microsoft.EntityFrameworkCore;

namespace Bernardino3ITE.Data
{
    public class AppDBContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>().HasData(
                new Student()
                {
                    Id = 1,
                    FirstName = "Gabriel",
                    LastName = "Montano",
                    Course = Course.BSIT,
                    AdmissionDate = DateTime.Parse("2022-08-26"),
                    GPA = 1.5,
                    Email = "ghaby021@gmail.com"
                },
                new Student()
                {
                    Id = 2,
                    FirstName = "Zyx",
                    LastName = "Montano",
                    Course = Course.BSIS,
                    AdmissionDate = DateTime.Parse("2022-08-07"),
                    GPA = 1,
                    Email = "zyx@gmail.com"
                },
                new Student()
                {
                    Id = 3,
                    FirstName = "Aerdriel",
                    LastName = "Montano",
                    Course = Course.BSCS,
                    AdmissionDate = DateTime.Parse("2020-01-25"),
                    GPA = 1.5,
                    Email = "aerdriel@gmail.com"
                });
            modelBuilder.Entity <Instructor>().HasData(
                new Instructor()
            {
                Id = 1,
                FirstName = "Aria",
                LastName = "Stormrider",
                HiringDate = new DateTime(2020, 03, 20),
                IsTenured = true,
                Rank = Rank.Instructor
            },
                new Instructor()
                {
                    Id = 2,
                    FirstName = "John",
                    LastName = "Smith",
                    HiringDate = new DateTime(2021, 04, 30),
                    IsTenured = false,
                    Rank = Rank.AssociateProfessor
                });
        }
    }
}
